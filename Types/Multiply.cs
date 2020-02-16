using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_17b60044_9125_4961_8a79_ca94697b3726
{
    public class Multiply : Instance<Multiply>
    {
        [Output(Guid = "e011dd8c-1b9c-458f-8960-e6c38e83ca74")]
        public readonly Slot<float> Result = new Slot<float>();

        public Multiply()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Result.Value = A.GetValue(context) * B.GetValue(context);
        }


        [Input(Guid = "372288fa-3794-47ba-9f91-59240513217a")]
        public readonly InputSlot<float> A = new InputSlot<float>();

        [Input(Guid = "5ae4bb07-4214-4ec3-a499-24d9f6d404a5")]
        public readonly InputSlot<float> B = new InputSlot<float>();
    }
}
