using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_a18ae2d3_1735_40b8_bebb_65a6788bc872 
{
    public class And : Instance<And>
    {
        [Output(Guid = "c02d701d-a915-4d2e-bb31-5c6cd27a999e")]
        public readonly Slot<bool> Result = new Slot<bool>();

        public And()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Result.Value = A.GetValue(context) & B.GetValue(context);
        }
        
        [Input(Guid = "1931b0fe-0df0-4ba1-9da5-b3eceaa87888")]
        public readonly InputSlot<bool> A = new InputSlot<bool>();

        [Input(Guid = "af89954f-9f79-4782-95ab-f40bb50339c8")]
        public readonly InputSlot<bool> B = new InputSlot<bool>();
    }
}
