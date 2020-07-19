using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_340e6898_c237_4287_acf0_62ec3eeb2b86
{
    public class TextOutlines : Instance<TextOutlines>
    {
        [Output(Guid = "d88eec27-ceb5-4b7c-91ef-5fa3b8c2291d")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "6fffe706-441a-4469-8067-b6549e12c08f")]
        public readonly InputSlot<string> Input = new InputSlot<string>();

        [Input(Guid = "aa83a930-4079-4922-9a5e-8f51f0178cd9")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "78b9036f-5c17-4aa6-aa83-74519d148c71")]
        public readonly InputSlot<System.Numerics.Vector2> Position = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "eec7ca6e-a4dd-48b3-88da-904212573c8a")]
        public readonly InputSlot<float> Size = new InputSlot<float>();

        [Input(Guid = "914fefd0-261a-48ba-b883-4f3b1a457df5")]
        public readonly InputSlot<float> LineHeight = new InputSlot<float>();

        [Input(Guid = "72da14b1-1738-43d4-95c8-ec21a20b7d2c")]
        public readonly InputSlot<int> VerticalAlign = new InputSlot<int>();

        [Input(Guid = "e869e217-adef-49e3-b8a7-bd693ebc53dd")]
        public readonly InputSlot<int> HorizontalAlign = new InputSlot<int>();

        [Input(Guid = "c2e35147-2a2f-499d-bd5c-ccdb4c8361c1")]
        public readonly InputSlot<float> Spacing = new InputSlot<float>();

        [Input(Guid = "f38f5da7-055b-4386-8490-764d13763b3a")]
        public readonly InputSlot<string> FontPath = new InputSlot<string>();

        [Input(Guid = "6463781c-4d15-40d1-b257-0f18a5481569")]
        public readonly InputSlot<int> Count = new InputSlot<int>();

        [Input(Guid = "32a8982f-1bc1-4cc3-b772-d5e62a813d8f")]
        public readonly InputSlot<float> Range = new InputSlot<float>();

        [Input(Guid = "53c34975-46f1-4e99-97eb-83e057e9ee91")]
        public readonly InputSlot<float> RangeOffset = new InputSlot<float>();

        [Input(Guid = "0a397456-3976-4d89-9bb3-8324b9a22d88")]
        public readonly InputSlot<float> StrokeRatio = new InputSlot<float>();

        [Input(Guid = "67f5ef8b-35da-4f0f-8326-51a74949faaf")]
        public readonly InputSlot<float> Feather = new InputSlot<float>();

        [Input(Guid = "32a1752d-655b-4940-b8aa-ab4da4f4b10f")]
        public readonly InputSlot<int> HighlightIndex = new InputSlot<int>();

        [Input(Guid = "7db6abf3-cab6-49ad-88b9-4a3a577baeca")]
        public readonly InputSlot<System.Numerics.Vector4> Highlight = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "646a65a0-e63b-41e2-9092-68670da98bee")]
        public readonly InputSlot<float> Shift = new InputSlot<float>();
    }
}

