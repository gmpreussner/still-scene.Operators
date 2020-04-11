using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_d75de240_28a1_48cc_9b8f_388272188023
{
    public class AfterGlow : Instance<AfterGlow>
    {
        [Output(Guid = "93c699c3-6d32-4425-8a00-6ce472bb808b")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();

        [Output(Guid = "36d50979-ceae-4087-886e-eeaf1b33d73b")]
        public readonly Slot<T3.Core.Command> CombinedLayers = new Slot<T3.Core.Command>();

        [Output(Guid = "5ce2a0cf-f9b7-4d86-b7a2-43a0d9e3d7ca")]
        public readonly Slot<float> ContrastOffset = new Slot<float>();

        [Input(Guid = "4a83673a-c0ec-4dba-9ce0-b71cb2ee0849")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Image = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "a4794ed9-d432-4118-9078-0a832cd1c046")]
        public readonly InputSlot<float> BlurAmount = new InputSlot<float>();

        [Input(Guid = "baa63233-d740-4978-b115-1f20975b53b0")]
        public readonly InputSlot<float> GlowImpact = new InputSlot<float>();

        [Input(Guid = "6ddbf04b-75ff-4e6e-b850-d28cb7fb8fc0")]
        public readonly InputSlot<float> DecayRate = new InputSlot<float>();

        [Input(Guid = "f9ef4416-3730-41ca-a1ae-336a0c3c52dd")]
        public readonly InputSlot<float> ContrastOffset2 = new InputSlot<float>();

        [Input(Guid = "9af9f8af-f7f6-465d-a35b-7b0d952a7db6")]
        public readonly InputSlot<SharpDX.Size2> Resolution = new InputSlot<SharpDX.Size2>();

    }
}

