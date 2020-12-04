using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using T3.Core;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Device = SharpDX.Direct3D11.Device;

namespace T3.Operators.Types.Id_49549c3e_b09e_4633_86c6_1ac075f56b69
{
    public class UseFallbackBuffer : Instance<UseFallbackBuffer>
    {
        [Output(Guid = "EF014AE5-962F-4A7B-9DCB-9E26863DD074")]
        public readonly Slot<BufferWithViews> Output = new Slot<BufferWithViews>();

        public UseFallbackBuffer()
        {
            Output.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var buffer = PrimaryBuffer.GetValue(context);
            if (buffer == null)
                buffer = Fallback.GetValue(context);
            
            Output.Value = buffer;
        }
        
        
        [Input(Guid = "7246FA40-3106-4D60-AB2C-5E913F3A9648")]
        public readonly InputSlot<BufferWithViews> PrimaryBuffer = new InputSlot<BufferWithViews>();
        
        [Input(Guid = "9904BD42-CBE5-4F83-AAB0-4973E1CBCBF8")]
        public readonly InputSlot<BufferWithViews> Fallback = new InputSlot<BufferWithViews>();
    }
}