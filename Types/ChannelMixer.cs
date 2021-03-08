using System.Numerics;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_51968877_03e7_472d_9b43_95bc8aeda3bc
{
    public class ChannelMixer : Instance<ChannelMixer>
    {
        [Output(Guid = "9cedcad7-1c8d-4aee-9168-67deae14248d")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();

        
        [Input(Guid = "28bb7ff9-190a-4624-9361-c4a530851bfd")]
        public readonly InputSlot<Texture2D> Texture2d = new InputSlot<Texture2D>();

        [Input(Guid = "5f3e8fc7-5b51-4502-aac2-d4cc282c985a")]
        public readonly InputSlot<System.Numerics.Vector4> MultiplyR = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "76e01cd7-15b8-4962-a96f-592e67ae51c5")]
        public readonly InputSlot<System.Numerics.Vector4> MultiplyG = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "1f380edd-ed50-49a4-976d-cce13783851d")]
        public readonly InputSlot<System.Numerics.Vector4> MultiplyB = new InputSlot<System.Numerics.Vector4>();
        
        [Input(Guid = "E68ED87B-FB06-43B2-A51F-A37A85FB6D87")]
        public readonly InputSlot<System.Numerics.Vector4> MultiplyA = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "1A0ACD15-34D1-4B8F-9739-F78BA204F315")]
        public readonly InputSlot<System.Numerics.Vector4> Add = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "8e25ab02-ef93-441c-8a16-78555093c5a6")]
        public readonly InputSlot<bool> GenerateMipmaps = new InputSlot<bool>();
    }
}