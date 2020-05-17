using System.Numerics;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_55411442_d538_48bf_ab78_b8c24c85aa46
{
    public class AdjustColors : Instance<AdjustColors>
    {
        [Output(Guid = "c4dcede0-34be-48a8-961e-1f8b7d4ada0a")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();

        [Input(Guid = "c325d01a-5232-4696-9b58-e24f72779597")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Texture2d = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "8cb24377-04ad-4bf3-b191-00a0f7af9989")]
        public readonly InputSlot<System.Numerics.Vector4> Colorize = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "74d63ccb-7ae5-45d9-af69-ad91b8582407")]
        public readonly InputSlot<float> Exposure = new InputSlot<float>();

        [Input(Guid = "e3395a18-619b-4fcc-b16c-c04d1df8afd9")]
        public readonly InputSlot<float> Contrast = new InputSlot<float>();

        [Input(Guid = "f6753ecc-a97e-4854-9f27-09bb9000858c")]
        public readonly InputSlot<float> Saturation = new InputSlot<float>();

        [Input(Guid = "4a10edf1-9bb4-4bd5-8455-357618f68ca9")]
        public readonly InputSlot<float> OrangeTeal = new InputSlot<float>();

        [Input(Guid = "008b025e-64eb-44c3-8959-dc8ac5dc2cbb")]
        public readonly InputSlot<System.Numerics.Vector2> PreventClamping = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "edcc911a-fa64-49fd-84d0-6fc0286c77db")]
        public readonly InputSlot<float> Brightness = new InputSlot<float>();

        [Input(Guid = "42d296cf-6c53-4da9-bef8-da36c4ca3aea")]
        public readonly InputSlot<float> Hue = new InputSlot<float>();

        [Input(Guid = "090c56b2-bbed-447e-baa1-5993b4e12ddc")]
        public readonly InputSlot<float> Vignette = new InputSlot<float>();

    }
}