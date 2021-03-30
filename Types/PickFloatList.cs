using System.Collections.Generic;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_6832d272_e63f_4ab2_b48c_85466b4ede1b
{
    public class PickFloatList : Instance<PickFloatList>
    {
        [Output(Guid = "32A7D943-E6AF-4186-9E1A-0800A62523C2")]
        public readonly Slot<List<float>> Selected = new Slot<List<float>>();

        public PickFloatList()
        {
            Selected.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var connections = Input.GetCollectedTypedInputs();
            if (connections == null || connections.Count == 0)
                return;

            var index = Index.GetValue(context);
            if (index < 0)
                index = -index;

            index %= connections.Count;
            Selected.Value = connections[index].GetValue(context);
        }

        [Input(Guid = "5A70A1AF-D6C5-43BF-ACB8-FCE2C9A2DE3C")]
        public readonly MultiInputSlot<List<float>> Input = new MultiInputSlot<List<float>>();

        [Input(Guid = "b22e2055-ccfd-4379-a3ef-d9b21d347f3d")]
        public readonly InputSlot<int> Index = new InputSlot<int>(0);
    }
}