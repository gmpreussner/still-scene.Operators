using System.Diagnostics;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_f376121a_2360_4232_9724_0db6937062c3
{
    public class HasValueDecreased : Instance<HasValueDecreased>
    {
        [Output(Guid = "2de049e8-77d3-4f01-9ba2-63ddeee935ba")]
        public readonly Slot<bool> HasDecreased = new Slot<bool>();
        

        public HasValueDecreased()
        {
            HasDecreased.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var v = Value.GetValue(context);
            
            var hasDecreased = v < _lastValue + Threshold.GetValue(context);
            if (hasDecreased != _lastDecrease)
            {
                _lastDecrease = hasDecreased;
                HasDecreased.Value = hasDecreased;
            }
            else
            {
                HasDecreased.Value = false;
            }
            _lastValue = v;
        }

        private float _lastValue = 0;
        private bool _lastDecrease;
        
        [Input(Guid = "0ce24e8e-7d35-41a1-85a5-0c55d4247a90")]
        public readonly InputSlot<float> Value = new InputSlot<float>();
        
        [Input(Guid = "332d2377-c5d3-448d-851f-26e3439720dc")]
        public readonly InputSlot<float> Threshold = new InputSlot<float>();

    }
}