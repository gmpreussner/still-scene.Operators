using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_8211249d_7a26_4ad0_8d84_56da72a5c536
{
    public class GradientSlider : Instance<GradientSlider>
    {
        [Output(Guid = "8c950a47-9642-4ad5-8bed-a7ea5acd27b6")]
        public readonly Slot<float> Result = new Slot<float>();
        
        [Output(Guid = "963611E7-F55E-4C94-96E6-34E195558A2B")]
        public readonly Slot<Vector4> Color = new Slot<Vector4>();

        [Output(Guid = "9F3D0701-86E8-436E-8652-918BA23B2CEF")]
        public readonly Slot<Gradient> OutGradient = new Slot<Gradient>();


        public GradientSlider()
        {
            Result.UpdateAction = Update;
            Color.UpdateAction = Update;
            OutGradient.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var input = this.SamplePos.GetValue(context);
            var gradient = Gradient.GetValue(context);
            
            Color.Value = gradient.Sample(input);
            OutGradient.Value = gradient.TypedClone();    //FIXME: This might not be efficient or required
        }

        [Input(Guid = "EFF10FAD-CF95-4133-91DB-EFC41258CD1B")]
        public readonly InputSlot<Gradient> Gradient = new InputSlot<Gradient>();
        
        [Input(Guid = "a4527e01-f19a-4200-85e5-00144f3ce061")]
        public readonly InputSlot<float> SamplePos = new InputSlot<float>();
    }
}
