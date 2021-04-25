using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_2d388f2b_3d07_4cbd_a86a_63c5cb83ed26
{
    public class ThereLetterBoxOverlay : Instance<ThereLetterBoxOverlay>
    {
        [Output(Guid = "532edc49-d0db-47e8-8e40-9acb7a32038e")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "6af229bb-f515-400a-9de8-a6f64c618e7c")]
        public readonly InputSlot<float> Float = new InputSlot<float>();

        [Input(Guid = "1885bd1c-d612-48e0-97db-5614e49d7c3e")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "df29f51e-74fc-4c15-8253-c6cf458d7927")]
        public readonly InputSlot<int> Direction = new InputSlot<int>();


    }
}

