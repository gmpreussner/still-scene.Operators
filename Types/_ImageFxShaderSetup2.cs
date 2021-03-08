using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_2b20afce_2b54_4bcc_ba0e_e456a0d92833
{
    public class _ImageFxShaderSetup2 : Instance<_ImageFxShaderSetup2>
    {
        [Output(Guid = "36e01dc9-0680-4af5-9329-0ac6a5f78f8c")]
        public readonly Slot<SharpDX.Direct3D11.Texture2D> TextureOutput = new Slot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "36abde68-0d79-4fb6-b8ce-ac8a27b66850")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Texture = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "16dce9bc-02d9-48f8-b07e-94a9af48d27b")]
        public readonly InputSlot<string> Source = new InputSlot<string>();

        [Input(Guid = "8e9b8826-5870-4db6-93c2-9fb469cfeec9")]
        public readonly MultiInputSlot<float> Params = new MultiInputSlot<float>();

        [Input(Guid = "c10f16e8-9e59-4b83-91b1-c2c7ad37d52a")]
        public readonly InputSlot<SharpDX.Size2> Resolution = new InputSlot<SharpDX.Size2>();

        [Input(Guid = "c80d3700-ceb6-43d0-9ffd-f4854e67a41d")]
        public readonly InputSlot<SharpDX.Direct3D11.TextureAddressMode> Wrap = new InputSlot<SharpDX.Direct3D11.TextureAddressMode>();

        [Input(Guid = "432c1a23-bf28-4595-923f-6c5a442fa90a")]
        public readonly InputSlot<SharpDX.DXGI.Format> OutputFormat = new InputSlot<SharpDX.DXGI.Format>();

        [Input(Guid = "499e7ff0-3b6a-414b-be19-03c615931ab8")]
        public readonly InputSlot<System.Numerics.Vector4> BufferColor = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "3ca67d25-72ec-487b-91b3-ece912b76462")]
        public readonly InputSlot<bool> GenerateMipmaps = new InputSlot<bool>();

        [Input(Guid = "9911dc7e-cd3b-4c58-a5d0-2e9abc8e528a")]
        public readonly InputSlot<int> BlendMode = new InputSlot<int>();

    }
}

