using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_09641970_b03a_431f_b3c6_5d8df824dde8
{
    public class Texture3dComponents : Instance<Texture3dComponents>
    {
        [Output(Guid = "a3772275-af0b-48e6-a3f8-ecd7c4c6eda4")]
        public readonly Slot<SharpDX.Direct3D11.Texture3D> Texture = new Slot<SharpDX.Direct3D11.Texture3D>();

        [Output(Guid = "4f9b2aeb-9bfd-400b-8839-45bec3ce2543")]
        public readonly Slot<SharpDX.Direct3D11.ShaderResourceView> ShaderResourceView = new Slot<SharpDX.Direct3D11.ShaderResourceView>();

        [Output(Guid = "45bef676-b9c1-45d2-964c-4a505471675b")]
        public readonly Slot<SharpDX.Direct3D11.UnorderedAccessView> UnorderedAccessView = new Slot<SharpDX.Direct3D11.UnorderedAccessView>();
        
        [Output(Guid = "bc7cfc1c-db71-4fd4-ba37-ede980400aa1")]
        public readonly Slot<SharpDX.Direct3D11.RenderTargetView> RenderTargetView = new Slot<SharpDX.Direct3D11.RenderTargetView>();

        public Texture3dComponents()
        {
            Texture.UpdateAction = Update;
            ShaderResourceView.UpdateAction = Update;
            UnorderedAccessView.UpdateAction = Update;
            RenderTargetView.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var texture3d = Input.GetValue(context);
            if (texture3d != null)
            {
                Texture.Value = texture3d.Texture;
                ShaderResourceView.Value = texture3d.Srv;
                UnorderedAccessView.Value = texture3d.Uav;
                RenderTargetView.Value = texture3d.Rtv;
            }
        }

        [Input(Guid = "29ded573-c67a-4f19-a988-8cd6473c98a6")]
        public readonly InputSlot<T3.Core.DataTypes.Texture3dWithViews> Input = new InputSlot<T3.Core.DataTypes.Texture3dWithViews>();
    }
}