using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_d32a5484_880c_41d4_88ea_6ee1a3e61f0b
{
    public class ContextCBuffers : Instance<ContextCBuffers>
    {
        [Output(Guid = "d4171c74-5a90-4fe9-8334-10f9701c284c", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<Buffer> FogParameters = new Slot<Buffer>();

        [Output(Guid = "5cb8c86e-c3a6-434c-b30a-a107121436b2", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<Buffer> PointLights = new Slot<Buffer>();

        public ContextCBuffers()
        {
            FogParameters.UpdateAction = Update;
            PointLights.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            FogParameters.Value = context.FogParameters;
            PointLights.Value = context.PointLights.ConstBuffer;
        }
    }
}