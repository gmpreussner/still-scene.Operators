using System;
using SharpDX;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_f2e323bd_f881_41a8_81e2_e8f2ac1984dc
{
    public class Float4ToVector4 : Instance<Float4ToVector4>
    {
        [Output(Guid = "14CDC3DD-F229-4F8F-B953-4F9D587D6F58")]
        public readonly Slot<System.Numerics.Vector4> Result = new Slot<System.Numerics.Vector4>();

        public Float4ToVector4()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Result.Value = new System.Numerics.Vector4(X.GetValue(context), Y.GetValue(context), Z.GetValue(context), W.GetValue(context));
        }
        
        [Input(Guid = "bdd35cdd-2220-4c58-9ec8-a5e48d7aaf7e")]
        public readonly InputSlot<float> X = new InputSlot<float>();

        [Input(Guid = "46a4ee87-ab2b-406b-a9ae-c000f887d99f")]
        public readonly InputSlot<float> Y = new InputSlot<float>();
        
        [Input(Guid = "59908ecc-1822-4aba-a2d9-cfe97168b3b3")]
        public readonly InputSlot<float> Z = new InputSlot<float>();
        
        [Input(Guid = "6CE53000-34D6-4D9A-AEF3-164FD223F6D2")]
        public readonly InputSlot<float> W = new InputSlot<float>();
    }
}
