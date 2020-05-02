using T3.Core.Animation;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b724ea74_d5d7_4928_9cd1_7a7850e4e179
{
    public class SampleCurve : Instance<SampleCurve>
    {
        [Output(Guid = "1A20C791-A1FE-4A14-A9CF-615691948F2D")]
        public readonly Slot<Curve> CurveOutput = new Slot<Curve>();
        
        [Output(Guid = "fc51bee8-091c-4c66-a7df-12f6f69e3783")]
        public readonly Slot<float> Result = new Slot<float>();
        
        public SampleCurve()
        {
            Result.UpdateAction = Update;
            Curve.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            if (Curve == null)
                return;
            
            var u = U.GetValue(context);
            var c = Curve.GetValue(context);
            
            CurveOutput.Value = c;
            
            if (c == null)
                return;
            
            Result.Value = (float)c.GetSampledValue(u);
        }

        [Input(Guid = "108CB829-5F9E-4A45-BC6B-7CF40A0A0F89")]
        public readonly InputSlot<Curve> Curve = new InputSlot<T3.Core.Animation.Curve>();

        [Input(Guid = "2c24d4fe-6c96-4502-bf76-dac756a16215")]
        public readonly InputSlot<float> U = new InputSlot<float>();
    }
}
