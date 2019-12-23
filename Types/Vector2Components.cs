using System.Numerics;
using T3.Core.Operator;

namespace T3.Operators.Types
{
    public class Vector2Components : Instance<Vector2Components>
    {
        [Output(Guid = "1cee5adb-8c3c-4575-bdd6-5669c04d55ce")]
        public readonly Slot<float> X = new Slot<float>();
        [Output(Guid = "305d321d-3334-476a-9fa3-4847912a4c58")]
        public readonly Slot<float> Y = new Slot<float>();

        public Vector2Components()
        {
            X.UpdateAction = Update;
            Y.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Vector2 value = Value.GetValue(context);
            X.Value = value.X;
            Y.Value = value.Y;
        }

        [Input(Guid = "36F14238-5BB8-4521-9533-F4D1E8FB802B")]
        public readonly InputSlot<System.Numerics.Vector2> Value = new InputSlot<Vector2>();

    }
}
