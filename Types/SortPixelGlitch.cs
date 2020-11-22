using System.Numerics;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_cbbb011c_f2bc_460e_86d0_48e49ed377fd
{
    public class SortPixelGlitch : Instance<SortPixelGlitch>
    {
        [Output(Guid = "5d93420b-af9c-45bb-8f48-0318b2718d88")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();

        [Input(Guid = "c1be39f5-9516-4a25-a57d-20aa56d68fa7")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Texture2d = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "615af268-5f30-4600-8c36-e37dbc2108c7")]
        public readonly InputSlot<bool> Vertical = new InputSlot<bool>();

        [Input(Guid = "10553b67-45f7-4e9d-b769-05865f4b2357")]
        public readonly InputSlot<bool> ScanHighlights = new InputSlot<bool>();

        [Input(Guid = "f3d77ff3-bd0c-4d36-93c3-5bb6cbc5397d")]
        public readonly InputSlot<float> Threshold = new InputSlot<float>();

        [Input(Guid = "f2eaa551-64f8-475f-b80a-a2b659393157")]
        public readonly InputSlot<float> Extend = new InputSlot<float>();

        [Input(Guid = "0d589063-aadf-47e5-8eb0-1c9beba104d0")]
        public readonly InputSlot<System.Numerics.Vector4> BackgroundColor = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "3c0a4fe5-25ae-4732-806f-7b7c1eb56da9")]
        public readonly InputSlot<System.Numerics.Vector4> StreakColor = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "cf4d392f-426a-4451-b752-25009e843a63")]
        public readonly InputSlot<float> GradientBias = new InputSlot<float>();

        [Input(Guid = "397bc44f-0cc1-480a-989a-a6dc83fe1965")]
        public readonly InputSlot<float> ScatterThreshold = new InputSlot<float>();

        [Input(Guid = "a5723b6f-571f-4741-a585-04a3b5a7b420")]
        public readonly InputSlot<float> Offset = new InputSlot<float>();

        [Input(Guid = "13c203e5-8a25-4872-9248-935599c1bd73")]
        public readonly InputSlot<float> ScatterOffset = new InputSlot<float>();

        [Input(Guid = "411f1a8e-5725-42e7-802b-c777ceaa9cd1")]
        public readonly InputSlot<float> AddGrain = new InputSlot<float>();

        [Input(Guid = "0a861871-a6d5-41f1-932d-639ca1afcaf7")]
        public readonly InputSlot<float> MaxSteps = new InputSlot<float>();

        [Input(Guid = "96bdee59-d3b7-4d93-939c-85cab836d6e5")]
        public readonly InputSlot<float> FadeStreaks = new InputSlot<float>();

        [Input(Guid = "ec8f4ff1-6b7a-4050-8086-2565c8f5d3fb")]
        public readonly InputSlot<float> LumaBias = new InputSlot<float>();

    }
}