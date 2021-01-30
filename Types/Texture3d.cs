using System;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_fc1ef086_c160_4174_8e60_a4eda931163d
{
    public class Texture3d : Instance<Texture3d>
    {
        // [Output(Guid = "27495e79-5229-4a2d-b780-52265c3085ea")]
        // public readonly Slot<Texture2D> Texture = new Slot<Texture2D>();
        [Output(Guid = "3cbfceaa-4fa1-44e9-8c43-aff7dba7f871")]
        public readonly Slot<Core.DataTypes.Texture3d> OutputTexture = new Slot<Core.DataTypes.Texture3d>(new Core.DataTypes.Texture3d());

        private uint _textureResId;

        public Texture3d()
        {
            OutputTexture.UpdateAction = UpdateTexture;
        }

        private void UpdateTexture(EvaluationContext context)
        {
            Int3 size = Size.GetValue(context);
            if (size.X < 1 || size.Y < 1 || size.Z < 1)
            {
                Log.Warning($"Requested invalid texture resolution: {size}");
                return;
            }

            var texDesc = new Texture3DDescription
                              {
                                  Width = size.X,
                                  Height = size.Y,
                                  Depth = size.Z,
                                  MipLevels = MipLevels.GetValue(context),
                                  Format = Format.GetValue(context),
                                  Usage = ResourceUsage.GetValue(context),
                                  BindFlags = BindFlags.GetValue(context),
                                  CpuAccessFlags = CpuAccessFlags.GetValue(context),
                                  OptionFlags = ResourceOptionFlags.GetValue(context)
                              };
            var rm = ResourceManager.Instance();
            rm.CreateTexture3d(texDesc, "Texture3D", ref _textureResId, ref OutputTexture.Value.Texture);
            if ((BindFlags.Value & SharpDX.Direct3D11.BindFlags.ShaderResource) > 0)
                rm.CreateShaderResourceView(_textureResId, "", ref OutputTexture.Value.Srv);
            if ((BindFlags.Value & SharpDX.Direct3D11.BindFlags.RenderTarget) > 0)
                rm.CreateRenderTargetView(_textureResId, "", ref OutputTexture.Value.Rtv);
            if ((BindFlags.Value & SharpDX.Direct3D11.BindFlags.UnorderedAccess) > 0)
                rm.CreateUnorderedAccessView(_textureResId, "", ref OutputTexture.Value.Uav);
        }

        [Input(Guid = "dca953d6-bdc1-42eb-9a4d-5974c42cf45b")]
        public readonly InputSlot<Int3> Size = new InputSlot<Int3>();

        [Input(Guid = "2e0fd6be-0c9e-4624-803c-178d1d80ea43")]
        public readonly InputSlot<int> MipLevels = new InputSlot<int>();

        [Input(Guid = "ce649059-f136-4d32-81c6-23d7b55f3378")]
        public readonly InputSlot<Format> Format = new InputSlot<Format>();

        [Input(Guid = "7db98a0e-2589-425b-95eb-d7614e82ed93")]
        public readonly InputSlot<ResourceUsage> ResourceUsage = new InputSlot<ResourceUsage>();

        [Input(Guid = "b824dbd6-272d-4744-a20d-5afa5caa9209")]
        public readonly InputSlot<BindFlags> BindFlags = new InputSlot<BindFlags>();

        [Input(Guid = "cfd3cfbf-7429-42f9-abc9-0e0e173f0297")]
        public InputSlot<CpuAccessFlags> CpuAccessFlags = new InputSlot<CpuAccessFlags>();

        [Input(Guid = "1884edfa-622b-4b96-a081-95dc361e79f3")]
        public InputSlot<ResourceOptionFlags> ResourceOptionFlags = new InputSlot<ResourceOptionFlags>();
    }
}