using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_475ea08b_0810_483f_bc6d_8b5d566cb8a2
{
    public class IntAdd : Instance<IntAdd>
    {
        [Output(Guid = "5e7233e6-7928-41a4-8f3f-b7d074614546")]
        public readonly Slot<int> Result = new Slot<int>();

        public IntAdd()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var a = Value1.GetValue(context);
            var b = Value2.GetValue(context);
            Result.Value = a + b;
        }
        
        [Input(Guid = "16dd5182-a0fb-4a26-b211-3c1bf3707579")]
        public readonly InputSlot<int> Value1 = new InputSlot<int>();

        [Input(Guid = "2ee7e022-49f9-4682-9266-a3f981da2240")]
        public readonly InputSlot<int> Value2 = new InputSlot<int>();
    }
}
