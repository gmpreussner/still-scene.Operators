﻿using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using T3.Core;
using T3.Core.Operator;

namespace T3.Operators.Types
{
    public class StructuredBuffer : Instance<StructuredBuffer>
    {
        [Output(Guid = "C10E66C8-C887-4A82-B557-642990581767")]
        public readonly Slot<SharpDX.Direct3D11.Buffer> Buffer = new Slot<SharpDX.Direct3D11.Buffer>();

        public StructuredBuffer()
        {
            Buffer.UpdateAction = UpdateBuffer;
        }

        private void UpdateBuffer(EvaluationContext context)
        {
            int stride = Stride.GetValue(context);
            int sizeInBytes = stride * Count.GetValue(context);

            if (sizeInBytes <= 0)
                return;

            ResourceManager.Instance().SetupIndirectBuffer(sizeInBytes, ref Buffer.Value);
        }

        [Input(Guid = "28E44436-F4E2-44EC-A28D-447E7A9F6BA8")]
        public readonly InputSlot<int> Stride = new InputSlot<int>();

        [Input(Guid = "B1CEDDFD-D289-41EB-BFC5-F36B789BFD4E")]
        public readonly InputSlot<int> Count = new InputSlot<int>();
    }
}