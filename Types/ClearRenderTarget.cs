using System.Numerics;
using SharpDX.Direct3D11;
using SharpDX.Mathematics.Interop;
using T3.Core;
using T3.Core.Operator;

namespace T3.Operators.Types
{
    public class ClearRenderTarget : Instance<ClearRenderTarget>
    {
        [Output(Guid = "A6C06F65-1738-4DD0-9D0F-728864FF521B")]
        public readonly Slot<Command> Output = new Slot<Command>();

        public ClearRenderTarget()
        {
            Output.UpdateAction = Update;
            Output.DirtyFlag.Trigger = DirtyFlagTrigger.Always;
        }

        private void Update(EvaluationContext context)
        {
            var resourceManager = ResourceManager.Instance();
            var device = resourceManager.Device;
            var deviceContext = device.ImmediateContext;
            // deviceContext.Draw2(VertexCount.GetValue(context), VertexStartLocation.GetValue(context));
            var rtv = RenderTarget.GetValue(context);
            if (rtv == null)
                return;

            var c = ClearColor.GetValue(context);
            deviceContext.ClearRenderTargetView(rtv, new RawColor4(c.X, c.Y, c.Z, c.W));
        }

        [Input(Guid = "D73D2FE7-1AF4-48D6-9AD3-F8C87C3369D6")]
        public readonly InputSlot<System.Numerics.Vector4> ClearColor = new InputSlot<Vector4>();
        [Input(Guid = "25C0C15C-5B95-4FE3-8D59-4E127FCE1CF2")]
        public readonly InputSlot<SharpDX.Direct3D11.RenderTargetView> RenderTarget = new InputSlot<RenderTargetView>();
    }
}