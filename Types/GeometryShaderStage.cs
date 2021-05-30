using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Buffer = SharpDX.Direct3D11.Buffer;

namespace T3.Operators.Types.Id_4abd5f2e_3296_4d71_8462_faa203091b1d
{
    public class GeometryShaderStage : Instance<GeometryShaderStage>
    {
        [Output(Guid = "07198b7f-62bc-400e-9e7f-848460b96e38")]
        public readonly Slot<Command> Output = new Slot<Command>(new Command());

        public GeometryShaderStage()
        {
            Output.UpdateAction = Update;
            Output.Value.RestoreAction = Restore;
        }

        private void Update(EvaluationContext context)
        {
            var resourceManager = ResourceManager.Instance();
            var device = resourceManager.Device;
            var deviceContext = device.ImmediateContext;
            var gsStage = deviceContext.GeometryShader;

            ConstantBuffers.GetValues(ref _constantBuffers, context);
            ShaderResources.GetValues(ref _shaderResourceViews, context);

            _prevConstantBuffers = gsStage.GetConstantBuffers(0, _constantBuffers.Length);
            _prevShaderResourceViews = gsStage.GetShaderResources(0, _shaderResourceViews.Length);
            _prevGeometryShader = gsStage.Get();

            var vs = GeometryShader.GetValue(context);
            if (vs == null)
                return;

            gsStage.Set(vs);
            gsStage.SetConstantBuffers(0, _constantBuffers.Length, _constantBuffers);
            gsStage.SetShaderResources(0, _shaderResourceViews.Length, _shaderResourceViews);
        }

        private void Restore(EvaluationContext context)
        {
            var deviceContext = ResourceManager.Instance().Device.ImmediateContext;
            var vsStage = deviceContext.GeometryShader;
            vsStage.Set(_prevGeometryShader);
            vsStage.SetConstantBuffers(0, _prevConstantBuffers.Length, _prevConstantBuffers);
            vsStage.SetShaderResources(0, _prevShaderResourceViews.Length, _prevShaderResourceViews);
        }

        private Buffer[] _constantBuffers = new Buffer[0];
        private ShaderResourceView[] _shaderResourceViews = new ShaderResourceView[0];

        private SharpDX.Direct3D11.GeometryShader _prevGeometryShader;
        private Buffer[] _prevConstantBuffers;
        private ShaderResourceView[] _prevShaderResourceViews;

        [Input(Guid = "2A217F9D-2F9F-418A-8568-F767905384D5")]
        public readonly InputSlot<SharpDX.Direct3D11.GeometryShader> GeometryShader = new InputSlot<SharpDX.Direct3D11.GeometryShader>();

        [Input(Guid = "380b3ea4-aab8-4e19-bd31-9af3aef834b4")]
        public readonly MultiInputSlot<Buffer> ConstantBuffers = new MultiInputSlot<Buffer>();

        [Input(Guid = "d17f9020-a7ad-4419-b11a-c48667cfc52e")]
        public readonly MultiInputSlot<ShaderResourceView> ShaderResources = new MultiInputSlot<ShaderResourceView>();

        [Input(Guid = "7173630b-d7fd-4aa1-9398-d7e028e5df03")]
        public readonly MultiInputSlot<SamplerState> SamplerStates = new MultiInputSlot<SamplerState>();
    }
}