using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SharpDX;
using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.DataTypes;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Buffer = SharpDX.Direct3D11.Buffer;

namespace T3.Operators.Types.Id_8f696d89_a23f_42ae_b382_8670febb546b 
{
    public class InitCATransitionBuffer : Instance<InitCATransitionBuffer>
    {
        [Output(Guid = "B0F31CB0-3D9F-426F-8E57-AAF94A5C8720", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<BufferWithViews> OutBuffer = new Slot<BufferWithViews>();

        [Output(Guid = "773C1811-203D-42CB-A84F-F9692FAAF1EF", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<int> TableLength = new Slot<int>();

        [Output(Guid = "F01DA1A4-0E60-45A8-BD9C-0F639F466A29", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<bool> WasUpdated = new Slot<bool>();
        
        public InitCATransitionBuffer()
        {
            OutBuffer.UpdateAction = Update;
            TableLength.UpdateAction = Update;
            WasUpdated.UpdateAction = Update;
        }

        private int _neighbourCount;
        private int _randomSeed;
        private int _stateCount;
        private int _ruleTableLength;
        private float _lambda;
        private int _requiredBitCount;
        private bool _isotropic;
        
        private void Update(EvaluationContext context)
        {
            var wasUpdate = false;
            
            var neighbourCount = NeighbourCount.GetValue(context).Clamp(1,9);
            var stateCount = StateCount.GetValue(context).Clamp(1,100);
            var seed = RandomSeed.GetValue(context);
            var lambda = Lambda.GetValue(context);
            var isotropic = Isotropic.GetValue(context);
            
            if (neighbourCount != _neighbourCount
                || stateCount != _stateCount
                || seed != _randomSeed
                || Math.Abs(lambda - _lambda) > 0.001f
                || isotropic != _isotropic)
            {
                wasUpdate = true;
                _neighbourCount = neighbourCount;
                _stateCount = stateCount;
                _randomSeed = seed;
                _lambda = lambda;
                _isotropic = isotropic;
                
                _requiredBitCount = (int)Math.Ceiling(Math.Log(_stateCount,2));
                _ruleTableLength = 1 << (_requiredBitCount * neighbourCount);
                
                if (_cellBuffer.Length != _ruleTableLength)
                {
                    _cellBuffer = new Cell[_ruleTableLength];
                }

                var rand = new Random(seed);
                
                var countPositives = 0f;
                //_lambda = 0.49f;
                for (var ruleIndex = 0; ruleIndex < _ruleTableLength; ruleIndex++)
                {
                    var choice = rand.NextDouble();
                    var nextState = (choice > _lambda || ruleIndex == 0) 
                                   ? 0
                                   : (rand.Next(stateCount-1) +1);
                    
                    if (nextState == 0)
                        countPositives++;
                    
                    _cellBuffer[ruleIndex] =  new Cell((uint)nextState);
                    _cellBuffer[FlipLookupIndex(ruleIndex)] = new Cell((uint)nextState); 
                }

                // Initialize with random
                // for (var ruleIndex = 0; ruleIndex < _ruleTableLength; ruleIndex++)
                // {
                //     var nextState = rand.Next(stateCount);
                //     _cellBuffer[ruleIndex] =  new Cell((uint)nextState);
                // }

                // Flip to approach lambda
                //var countPositives = 0f;
                // int step = _ruleTableLength/6;
                // for (var ruleIndex = 0; ruleIndex < _ruleTableLength; ruleIndex+= step)
                // {
                //     var currentL = MeasureLambda();
                //     if (currentL < _lambda)
                //     {
                //         _cellBuffer[ruleIndex] =  new Cell((uint)rand.Next(stateCount-1)+1);    
                //         _cellBuffer[FlipLookupIndex(ruleIndex)] =  new Cell((uint)rand.Next(stateCount-1)+1);
                //     }
                //     else
                //     {
                //         _cellBuffer[ruleIndex] =   new Cell(0);
                //         _cellBuffer[FlipLookupIndex(ruleIndex)] =  new Cell(0);
                //     }
                //     //countPositives++;
                // }

                
                Log.Debug($" Lambda:  {MeasureLambda()}");                
                
                const int stride = 4;
                var resourceManager = ResourceManager.Instance();
                _bufferWithViews.Buffer = _buffer;
                resourceManager.SetupStructuredBuffer(_cellBuffer, stride * _cellBuffer.Length, stride, ref _buffer);
                resourceManager.CreateStructuredBufferSrv(_buffer, ref _bufferWithViews.Srv);
                resourceManager.CreateStructuredBufferUav(_buffer, UnorderedAccessViewBufferFlags.None, ref _bufferWithViews.Uav);
            }
            
            OutBuffer.Value = _bufferWithViews;
            TableLength.Value = _ruleTableLength;
            WasUpdated.Value = wasUpdate;
        }

        private int FlipLookupIndex(int index)
        {
            if (!_isotropic)
            {
                return index;
            }

            int mask = (1 << _requiredBitCount) - 1;
            int combinedResult = 0;
            for (int i = 0; i < _neighbourCount; i++)
            {
                var shiftedLowAndMasked = (index >> (i * _requiredBitCount)) & mask;
                var shiftedUp = shiftedLowAndMasked << ((_neighbourCount - i - 1) * _requiredBitCount);
                combinedResult |= shiftedUp;
            }

            if (combinedResult >= _ruleTableLength)
            {
                Log.Warning($"  NOPE: {combinedResult} exceed table {_ruleTableLength}");
                combinedResult = 0;
            }

            return combinedResult;
        }
        
        private float MeasureLambda()
        {
            var countQuiescence = 0;
            for (var ruleIndex = 0; ruleIndex < _ruleTableLength; ruleIndex++)
            {
                if(_cellBuffer[ruleIndex].State ==0)
                    countQuiescence++;
            }

            return 1-(float)countQuiescence / _ruleTableLength;
        }
        
        private Cell[] _cellBuffer = new Cell[0];
        private Buffer _buffer;
        private readonly BufferWithViews _bufferWithViews = new BufferWithViews();

        [StructLayout(LayoutKind.Explicit, Size = 4)]
        public struct Cell
        {
            public Cell(uint state)
            {
                State = state;
            }

            [FieldOffset(0)]
            public uint State;
        }       
        
        [Input(Guid = "42C3E0A8-5C19-4037-91E9-2B55196F5DE3")]
        public readonly InputSlot<int> StateCount = new InputSlot<int>();
        
        [Input(Guid = "8E58A20D-B260-43BD-BE1C-9C2D3F76A715")]
        public readonly InputSlot<int> NeighbourCount = new InputSlot<int>();
        
        [Input(Guid = "0ED09B7A-F9D3-4C81-886A-73503A6D783C")]
        public readonly InputSlot<int> RandomSeed = new InputSlot<int>();
        
        [Input(Guid = "7114429B-DE14-41E4-91F9-BC023D9F8F60")]
        public readonly InputSlot<float> Lambda = new InputSlot<float>();
        
        [Input(Guid = "3874EE49-998A-4D9B-A605-FDCB56C3CA52")]
        public readonly InputSlot<bool> Isotropic = new InputSlot<bool>();
    }
}
