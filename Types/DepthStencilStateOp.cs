using System.Collections.Generic;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Mathematics.Interop;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_04858a08_f0fe_4536_9152_686659f0ab58
{
    public class DepthStencilStateOp : Instance<DepthStencilStateOp>
    {
        [Output(Guid = "26E300CD-2DBE-49F2-AAB5-A60317DF5434")]
        public readonly Slot<DepthStencilState> DepthState = new Slot<DepthStencilState>();

        public DepthStencilStateOp()
        {
            DepthState.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            DepthState.Value?.Dispose();

            try
            {
                var depthStencilStateDescription = new DepthStencilStateDescription()
                {
                    IsDepthEnabled = IsEnabled.GetValue(context),
                    DepthWriteMask = DepthWriteMask.All,
                    DepthComparison = Comparison.GetValue(context),
                    
                };
                
                DepthState.Value = new DepthStencilState(ResourceManager.Instance().Device, depthStencilStateDescription);
                
            }
            catch (SharpDXException e)
            {
                Log.Error("Failed to create DepthStencilState " + e.Message);
            } 
        }

        [Input(Guid = "956B735B-C38A-4E8E-8186-CAF4D36D4D20")]
        public readonly InputSlot<bool> IsEnabled = new InputSlot<bool>();
        
        [Input(Guid = "27F1F703-7333-49E5-A024-4606E34E8427")]
        public readonly InputSlot<Comparison> Comparison = new InputSlot<Comparison>(SharpDX.Direct3D11.Comparison.Less);
        
    }
}