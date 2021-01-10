using System.Numerics;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_13d5260d_4e50_48f8_909c_7d84d6f0a43f
{
    public class UglySSAO : Instance<UglySSAO>
    {
        [Output(Guid = "9be415b6-b7f0-4b8f-8d93-c147ef8d0d44")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();

        [Input(Guid = "450023da-53fb-4e36-9936-551a2ebcce84")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Texture2d = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "938b9656-f0ad-4f4c-be45-e56185f7a94a")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> DepthBuffer = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "602f3004-59ef-4065-a9a6-3c14fab79c6c")]
        public readonly InputSlot<System.Numerics.Vector2> NearFarRange = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "40e22707-5c08-4c64-adcb-080b50aeb4f6")]
        public readonly InputSlot<System.Numerics.Vector2> NearFarClip = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "12cd23ef-82ea-41b3-a8da-72bb66018d86")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "e54a0202-19ab-42f8-bd7d-ae2881d58ea2")]
        public readonly InputSlot<System.Numerics.Vector2> BoostShadows = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "c310f731-bc13-44e7-a827-d8e4f996ff99")]
        public readonly InputSlot<float> Passes = new InputSlot<float>();

        [Input(Guid = "592b84f4-e53c-499a-ab83-150e0eabfcdf")]
        public readonly InputSlot<float> Size = new InputSlot<float>();

        [Input(Guid = "9ac4806b-bbcf-4b29-ac15-4bc7f52ef192")]
        public readonly InputSlot<float> MixOriginal = new InputSlot<float>();

        [Input(Guid = "0fb4d665-3014-48a4-b544-c5d28d699fc4")]
        public readonly InputSlot<float> MultiplyOriginal = new InputSlot<float>();

        [Input(Guid = "c7c1d642-851e-41a8-895d-df28b5bb770e")]
        public readonly InputSlot<System.Numerics.Vector2> NoiseOffset = new InputSlot<System.Numerics.Vector2>();

    }
}