using System.Diagnostics;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_52c92cd8_241e_4d79_aebc_b60b092f7941
{
    public class IsGreater : Instance<IsGreater>
    {
        [Output(Guid = "67e68f72-9bcb-4012-91f3-47d16a8efbaf")]
        public readonly Slot<bool> Result = new Slot<bool>();
        

        public IsGreater()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var v = Value.GetValue(context);
            var t = Threshold.GetValue(context);
            
            var result = v > t;

            if (result == _lastResult)
                return;

            Result.Value = result;
            _lastResult = result;
        }

        private bool _lastResult;

        [Input(Guid = "0cca00d1-ebad-4bef-9d87-b40be2568b61")]
        public readonly InputSlot<float> Value = new InputSlot<float>();
        
        [Input(Guid = "0FED5B94-0284-419D-A53A-0600B3B9B62D")]
        public readonly InputSlot<float> Threshold = new InputSlot<float>();

    }
}