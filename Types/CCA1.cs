using System.Numerics;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_6d9cfb3f_805a_4f62_80b5_52e792b4af30
{
    public class CCA1 : Instance<CCA1>
    {
        [Output(Guid = "946934e2-481a-4375-8e56-1e1bc1c7ad50")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();

        [Input(Guid = "78b6c005-2ab5-48e3-af81-2daa0d75c00f")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Texture2d = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "0e7ada5a-da80-4709-a65a-ccd34da3d0e3")]
        public readonly InputSlot<float> Threshold = new InputSlot<float>();

        [Input(Guid = "c3263db8-ab82-4fc7-816c-ca72f46ccebc")]
        public readonly InputSlot<float> MaxSteps = new InputSlot<float>();

        [Input(Guid = "70687eb5-3a37-4d58-8792-5c2f5a8d9820")]
        public readonly InputSlot<float> Range = new InputSlot<float>();

        [Input(Guid = "1255130d-b0c0-4215-9cb0-bed7614cf19f")]
        public readonly InputSlot<float> Increment = new InputSlot<float>();

        [Input(Guid = "36292444-3233-4a43-ab34-328fca44e101")]
        public readonly InputSlot<float> RandomSeed = new InputSlot<float>();

        [Input(Guid = "064bedfa-a6c5-4e29-8f36-95846137e288")]
        public readonly InputSlot<float> RandomAmount = new InputSlot<float>();

        [Input(Guid = "dbddac40-2add-4b39-9edb-62baa25509fe")]
        public readonly InputSlot<bool> AddNoise2 = new InputSlot<bool>();

        [Input(Guid = "43f5c64e-d0ab-4808-a0a5-c6b90119112c")]
        public readonly InputSlot<bool> SlowDown = new InputSlot<bool>();

    }
}