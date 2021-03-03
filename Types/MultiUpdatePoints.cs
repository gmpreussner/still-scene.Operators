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

namespace T3.Operators.Types.Id_62c89469_7194_486a_87cd_c3e6bc0cf5d2
{
    public class MultiUpdatePoints : Instance<MultiUpdatePoints>
    {
        [Output(Guid = "5556392D-8884-4922-B5AD-AFA474E36C02")]
        public readonly Slot<BufferWithViews> Result = new Slot<BufferWithViews>();
        
        
        public MultiUpdatePoints()
        {
            Result.UpdateAction = Update;
        }


        private void Update(EvaluationContext context)
        {
            var connectedLists = PointBuffers.CollectedInputs.Select(c => c.GetValue(context)).Where(c => c != null).ToList();
            PointBuffers.DirtyFlag.Clear();
            
            if (connectedLists.Count == 0)
            {
                Result.Value = null;
                return;
            }

            BufferWithViews input = connectedLists[0];
            for (var index = 1; index < connectedLists.Count; index++)
            {
                var cl = connectedLists[index];
                if (cl != input)
                {
                    Log.Warning($"Inconsistent buffers connected to MultiUpdatePoints on index {index}", SymbolChildId);
                }
            }

            Result.Value = connectedLists[connectedLists.Count - 1];
        }


        [Input(Guid = "7CAA2F8C-64E1-4941-BD1C-8BDC89584BA7")]
        public readonly MultiInputSlot<BufferWithViews> PointBuffers = new MultiInputSlot<BufferWithViews>();
    }
}