using System;
using System.Linq;
using SharpDX;
using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.DataTypes;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Buffer = SharpDX.Direct3D11.Buffer;

namespace T3.Operators.Types.Id_7e28c796_85e7_47ee_99bb_9599284dbeeb
{
    public class ListToBuffer : Instance<ListToBuffer>
    {
        [Output(Guid = "c52dfa83-9820-4a54-b90b-62278dc8fe3f")]
        public readonly Slot<BufferWithViews> OutBuffer = new Slot<BufferWithViews>();

        [Output(Guid = "e1775fdf-af5a-49b2-b6fc-20e2180b71f5")]
        public readonly Slot<int> Length = new Slot<int>();

        public ListToBuffer()
        {
            OutBuffer.UpdateAction = Update;
            Length.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var listsCollectedInputs = Lists.CollectedInputs.Select(c => c.GetValue(context)).Where(c => c != null).ToList();
            Lists.DirtyFlag.Clear();

            if (listsCollectedInputs.Count == 0)
            {
                OutBuffer.Value = null;
                Length.Value = 0;
                return;
            }

            var totalSizeInBytes = 0;
            foreach (var entry in listsCollectedInputs)
            {
                if (entry == null)
                    continue;

                totalSizeInBytes += entry.TotalSizeInBytes;
            }

            if (totalSizeInBytes == 0)
            {
                _buffer = null;
                Length.Value = 0;
            }
            else
            {
                var resourceManager = ResourceManager.Instance();
                using (var data = new DataStream(totalSizeInBytes, true, true))
                {
                    foreach (var entry in listsCollectedInputs)
                    {
                        entry?.WriteToStream(data);
                    }

                    data.Position = 0;

                    var firstInputList = listsCollectedInputs.FirstOrDefault();
                    var elementSizeInBytes = firstInputList?.ElementSizeInBytes ?? 0; // todo: add check that all inputs have same type
                    try
                    {
                        resourceManager.SetupStructuredBuffer(data, totalSizeInBytes, elementSizeInBytes, ref _buffer);
                    }
                    catch (Exception e)
                    {
                        Log.Error("Failed to setup structured buffer " + e.Message, SymbolChildId);
                        return;
                    }

                    var elementCount = totalSizeInBytes / elementSizeInBytes;
                    Length.Value = elementCount;
                }
                resourceManager.CreateStructuredBufferSrv(_buffer, ref _bufferWithViews.Srv);
                resourceManager.CreateStructuredBufferUav(_buffer, UnorderedAccessViewBufferFlags.None, ref _bufferWithViews.Uav);
            }

            _bufferWithViews.Buffer = _buffer;
            OutBuffer.Value = _bufferWithViews;
            
        }

        private Buffer _buffer;
        private readonly BufferWithViews _bufferWithViews = new BufferWithViews();

        [Input(Guid = "08F181BB-9777-497C-871D-BCC1FF252F2F")]
        public readonly MultiInputSlot<StructuredList> Lists = new MultiInputSlot<StructuredList>();
    }
}