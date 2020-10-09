﻿using System;
using System.Diagnostics;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_8c41b312_6628_411c_a61d_604413b73a72
{
    public class SrvFromStructuredBuffer : Instance<SrvFromStructuredBuffer>
    {
        [Output(Guid = "2A1FCDF6-9416-45B2-96CA-A9D6D2692278")]
        public readonly Slot<ShaderResourceView> ShaderResourceView = new Slot<ShaderResourceView>();

        [Output(Guid = "E96EED5C-AE63-49B7-8ADD-2A818E4A2B89")]
        public readonly Slot<int> ElementCount = new Slot<int>();
        
        public SrvFromStructuredBuffer()
        {
            ShaderResourceView.UpdateAction = Update;
            ElementCount.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var resourceManager = ResourceManager.Instance();
            var buffer = Buffer.GetValue(context);
            if (buffer != null)
            {
                if ((buffer.Description.OptionFlags & ResourceOptionFlags.BufferStructured) == 0)
                {
                    Log.Warning($"{nameof(SrvFromStructuredBuffer)} - input buffer is not structured, skipping SRV creation.");
                    return;
                }
                ShaderResourceView.Value?.Dispose();

                var elementCount = buffer.Description.SizeInBytes / buffer.Description.StructureByteStride;
                var desc = new ShaderResourceViewDescription()
                               {
                                   Dimension = ShaderResourceViewDimension.ExtendedBuffer,
                                   Format = Format.Unknown,
                                   BufferEx = new ShaderResourceViewDescription.ExtendedBufferResource()
                                                  {
                                                      FirstElement = 0,
                                                      ElementCount = elementCount
                                                  }
                               };
                ShaderResourceView.Value = new ShaderResourceView(resourceManager.Device, buffer, desc); // todo: create via resource manager
                ElementCount.Value = elementCount;
            }
        }

        [Input(Guid = "BD65EF2C-F32A-4279-BB5C-7F6467B23283")]
        public readonly InputSlot<SharpDX.Direct3D11.Buffer> Buffer = new InputSlot<SharpDX.Direct3D11.Buffer>();
    }
}