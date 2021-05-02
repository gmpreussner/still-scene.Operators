using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_7129684e_bf84_4c8b_996e_baba68094585 
{
    public class Ceil : Instance<Ceil>
    {
        [Output(Guid = "bc97d61a-0e23-469c-83d9-4a687c8e0016")]
        public readonly Slot<float> Result = new Slot<float>();

        public Ceil()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var v = Value.GetValue(context);
            Result.Value = (float)Math.Ceiling(v);
        }
        
        [Input(Guid = "a0f6f860-9561-4af8-9660-05cfb2f995a0")]
        public readonly InputSlot<float> Value = new InputSlot<float>();
    }
}
