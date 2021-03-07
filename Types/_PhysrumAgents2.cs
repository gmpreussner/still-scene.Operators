using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_c0feef61_8cec_4418_8889_4001cbe1a957
{
    public class _PhysrumAgents2 : Instance<_PhysrumAgents2>
    {
        [Output(Guid = "9dd9d899-c1b2-4c63-b338-b779b2278f86")]
        public readonly Slot<Texture2D> ImgOutput = new Slot<Texture2D>();

        [Output(Guid = "ca414af7-1bcf-4134-baf0-9f2f06756a5c")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Points = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "bc0f0973-68c1-4f33-801d-9e9db29f7513")]
        public readonly InputSlot<bool> ShowAgents = new InputSlot<bool>();

        [Input(Guid = "cf5837f9-df50-43d2-97db-07595d91828f")]
        public readonly InputSlot<SharpDX.Size2> Resolution = new InputSlot<SharpDX.Size2>();

        [Input(Guid = "1aff9d51-48d0-4d36-93f3-be97c8533201")]
        public readonly InputSlot<int> ComputeSteps = new InputSlot<int>();

        [Input(Guid = "a92f43c8-2d17-4664-b9ed-17872ec68498")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> BreedsBuffer = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "c88f4355-fd80-4e66-8dca-5860d1ca2241")]
        public readonly InputSlot<System.Numerics.Vector4> DecayRatio = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "6516ba78-3b9a-475d-88b7-f88337f6686b")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> EffectTexture = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "5100f7d8-a5e0-4630-b646-2db20e0cc4be")]
        public readonly InputSlot<SharpDX.Size2> BlockCount = new InputSlot<SharpDX.Size2>();

        [Input(Guid = "e06937b8-99f7-418b-b352-a42a3a63bf5b")]
        public readonly InputSlot<float> FXRedFro_Rotate = new InputSlot<float>();

        [Input(Guid = "57e49ac9-a223-4f92-bdba-3675e988f77e")]
        public readonly InputSlot<float> FXGreenFor_FrontRadius = new InputSlot<float>();

        [Input(Guid = "56050b00-e2ca-4140-8147-4f53c0829908")]
        public readonly InputSlot<float> FXBlueFor_SideAngle = new InputSlot<float>();

        [Input(Guid = "8f74bb82-393c-4594-b92c-fbe6adfa8ed5")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> SeedTexture = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "bdedd5d8-a1b9-4e2d-ba7e-824ee1fdfcba")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> PointsBuffer = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "60c55f37-2a74-44bd-a90d-041501496d76")]
        public readonly InputSlot<bool> IsEnabled = new InputSlot<bool>();


    }
}

