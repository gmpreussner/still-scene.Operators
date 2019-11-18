using System;
using T3.Core.Operator;

namespace T3.Operators.Types
{
    public class Value : Instance<Value>
    {
        [Output(Guid = "f83f1835-477e-4bb6-93f0-14bf273b8e94")]
        public readonly Slot<float> Result = new Slot<float>();

        public Value()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Result.Value = Float.GetValue(context);
        }
        
        [Input(Guid = "7773837e-104a-4b3d-a41f-cadbd9249af2")]
        public readonly InputSlot<float> Float = new InputSlot<float>();
    }
}