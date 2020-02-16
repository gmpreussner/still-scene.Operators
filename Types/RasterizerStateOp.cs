﻿using System;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;

namespace T3.Operators.Types.Id_c7283335_ef57_46ad_9538_abbade65845a
{
    public class RasterizerStateOp : Instance<RasterizerStateOp>
    {
        [Output(Guid = "B409694A-0980-4992-8525-01871B940CD7")]
        public readonly Slot<RasterizerState> RasterizerState = new Slot<RasterizerState>();

        public RasterizerStateOp()
        {
            RasterizerState.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            RasterizerState.Value?.Dispose();
            var rasterizerDesc = new RasterizerStateDescription()
                                 {
                                     CullMode = CullMode.GetValue(context),
                                     DepthBias = DepthBias.GetValue(context),
                                     DepthBiasClamp = DepthBiasClamp.GetValue(context),
                                     FillMode = FillMode.GetValue(context),
                                     IsAntialiasedLineEnabled = AntialiasedLineEnabled.GetValue(context),
                                     IsDepthClipEnabled = DepthClipEnabled.GetValue(context),
                                     IsFrontCounterClockwise = FrontCounterClockwise.GetValue(context),
                                     IsMultisampleEnabled = MultiSampleEnabled.GetValue(context),
                                     IsScissorEnabled = ScissorEnabled.GetValue(context),
                                     SlopeScaledDepthBias = SlopeScaledDepthBias.GetValue(context)
                                 };
            RasterizerState.Value = new RasterizerState(ResourceManager.Instance().Device, rasterizerDesc); // todo: put into resource manager
        }

        [Input(Guid = "03F3BC7F-3949-4A97-88CF-04E162CFA2F7")]
        public readonly InputSlot<CullMode> CullMode = new InputSlot<CullMode>();
        [Input(Guid = "A2193AA0-E217-4248-A8DC-360CB89A613B")]
        public readonly InputSlot<int> DepthBias = new InputSlot<int>();
        [Input(Guid = "2B53507E-24C3-4895-8928-3400C6ACCCB6")]
        public readonly InputSlot<float> DepthBiasClamp = new InputSlot<float>();
        [Input(Guid = "F4E8844C-E4F3-42BB-8103-C99149543B23")]
        public readonly InputSlot<FillMode> FillMode = new InputSlot<FillMode>();
        [Input(Guid = "EEB75A91-2402-44BE-BB9D-B620E34085ED")]
        public readonly InputSlot<bool> AntialiasedLineEnabled = new InputSlot<bool>();
        [Input(Guid = "33D5BCFA-996A-4019-9E80-D15B72EA9D4C")]
        public readonly InputSlot<bool> DepthClipEnabled = new InputSlot<bool>();
        [Input(Guid = "31319FB4-8663-4908-95B8-E5D5A95F15B2")]
        public readonly InputSlot<bool> FrontCounterClockwise = new InputSlot<bool>();
        [Input(Guid = "A6DCBF5C-7096-4023-878C-70495AD76F83")]
        public readonly InputSlot<bool> MultiSampleEnabled = new InputSlot<bool>();
        [Input(Guid = "DFCA315F-85DE-439A-A0B4-30FDF8DA050E")]
        public readonly InputSlot<bool> ScissorEnabled = new InputSlot<bool>();
        [Input(Guid = "03C80C25-B0B1-45C2-B67B-60906FE47FBE")]
        public readonly InputSlot<float> SlopeScaledDepthBias = new InputSlot<float>();
    }
}