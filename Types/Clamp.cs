using System;
using SharpDX;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_c3a18346_930c_4242_9e42_aa9b3a439395 
{
    public class Clamp : Instance<Clamp>
    {
        [Output(Guid = "7267b39a-bc11-450c-950e-e87701156546")]
        public readonly Slot<float> Result = new Slot<float>();

        public Clamp()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var v = Value.GetValue(context);
            var min = Min.GetValue(context);
            var max = Max.GetValue(context);
            Result.Value = MathUtil.Clamp(v, min, max);
        }
        
        [Input(Guid = "eb002b5d-b938-4b03-b2ea-26252ae051cd")]
        public readonly InputSlot<float> Value = new InputSlot<float>();

        [Input(Guid = "7224ad5c-d179-4eab-b52d-72e277d007ae")]
        public readonly InputSlot<float> Min = new InputSlot<float>();
        
        [Input(Guid = "54C0E659-7FDA-459F-9938-DEEEE0CFA11C")]
        public readonly InputSlot<float> Max = new InputSlot<float>();

        
    }
}
