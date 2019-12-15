using System;
using T3.Core.Operator;

namespace T3.Operators.Types
{
    public class String : Instance<String>
    {
        [Output(Guid = "dd9d8718-addc-49b1-bd33-aac22b366f94")]
        public readonly Slot<string> Result = new Slot<string>();

        public String()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Result.Value = InputString.GetValue(context);
        }
        
        [Input(Guid = "ceeae47b-d792-471d-a825-49e22749b7b9")]
        public readonly InputSlot<string> InputString = new InputSlot<string>();
    }
}