using System;
using System.Diagnostics;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_0e1d5f4b_3ba0_4e71_aa26_7308b6df214d
{
    public class CountInt : Instance<CountInt>
    {
        [Output(Guid = "2E172F90-3995-4B16-AF33-9957BE07323B")]
        public readonly Slot<int> Result = new Slot<int>();

        public CountInt()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            if (!_initialized || TriggerReset.GetValue(context))
            {
                Result.Value = DefaultValue.GetValue(context);
                _initialized = true;
            }

            var triggered = Trigger.GetValue(context);
            if (OnlyCountChanges.GetValue(context) && triggered == _lastTrigger)
                return;

            _lastTrigger = triggered;

            if (triggered)
                Result.Value++;
        }

        private bool _initialized;
        private bool _lastTrigger;

        [Input(Guid = "bfd95809-61d2-49eb-85d4-ff9e36b2d158")]
        public readonly InputSlot<bool> Trigger = new InputSlot<bool>();

        [Input(Guid = "01027ce6-f4ca-44b6-a8ec-e4ab96280864")]
        public readonly InputSlot<bool> TriggerReset = new InputSlot<bool>();

        [Input(Guid = "518A8BD6-D830-4F73-AC83-49BE2FD4B09D")]
        public readonly InputSlot<bool> OnlyCountChanges = new InputSlot<bool>();

        [Input(Guid = "11F9CDB5-84FC-4413-8CA7-77E12047F521")]
        public readonly InputSlot<int> DefaultValue = new InputSlot<int>();
    }
}