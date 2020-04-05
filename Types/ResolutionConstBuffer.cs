using SharpDX;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using System.Runtime.InteropServices;
using T3.Core;

namespace T3.Operators.Types.Id_38e88910_6063_41d1_840b_8aeeb0eeccc0
{
    public class ResolutionConstBuffer : Instance<ResolutionConstBuffer>
    {
        [Output(Guid = "{FE020A5C-91E1-441F-BE0D-AB5900D150EB}")]
        public readonly Slot<SharpDX.Direct3D11.Buffer> Buffer = new Slot<SharpDX.Direct3D11.Buffer>();

        public ResolutionConstBuffer()
        {
            Buffer.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var bufferContent = new ResolutionBufferLayout(Resolution.GetValue(context));
            ResourceManager.Instance().SetupConstBuffer(bufferContent, ref Buffer.Value);
            Buffer.Value.DebugName = nameof(ResolutionBufferLayout);
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public struct ResolutionBufferLayout
        {
            public ResolutionBufferLayout(Size2 resolution)
            {
                Width = resolution.Width;
                Height = resolution.Height;
            }

            [FieldOffset(0)]
            public float Height;
            [FieldOffset(4)]
            public float Width;
        }
        
        [Input(Guid = "3BBA98BD-2713-4E5B-B082-20B39392EF9B")]
        public readonly InputSlot<Size2> Resolution = new InputSlot<Size2>();
    }
}
        
        
