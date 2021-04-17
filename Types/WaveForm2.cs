using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_92e28e50_bd40_4f93_ba92_8f69cded6ec1
{
    public class WaveForm2 : Instance<WaveForm2>
    {
        [Output(Guid = "d81d0fd1-3ba0-4576-8fea-d37fb6ec5548")]
        public readonly Slot<Texture2D> ImgOutput = new Slot<Texture2D>();

        [Input(Guid = "73afdd61-dd59-4018-a473-025272deab93")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> EffectTexture = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "cf46bbff-86cc-43db-a712-1ca0a90d34a1")]
        public readonly InputSlot<float> Height = new InputSlot<float>();

        [Input(Guid = "f975a9bb-26db-4683-abe7-88e900787610")]
        public readonly InputSlot<float> Opacity = new InputSlot<float>();

        [Input(Guid = "381d9aa5-2685-4509-9640-1dcca64746fa")]
        public readonly InputSlot<float> DimBackground = new InputSlot<float>();

        [Input(Guid = "d86c228c-f586-471e-ab07-4414375de29a")]
        public readonly InputSlot<float> ColorIntensity = new InputSlot<float>();

        [Input(Guid = "3a226812-98bf-4fe9-b435-f84b154a41e8")]
        public readonly InputSlot<SharpDX.Size2> OverrideSize = new InputSlot<SharpDX.Size2>();

        [Input(Guid = "5ce4b7d6-ecaf-44d9-aa67-74892339cb06")]
        public readonly InputSlot<float> EnlargeVectorScopeCenter = new InputSlot<float>();


    }
}

