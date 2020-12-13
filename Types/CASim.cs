using System.Numerics;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_2b6981f8_f66c_4132_9f37_6536d477ed65
{
    public class CASim : Instance<CASim>
    {
        [Output(Guid = "b55532fe-9582-46cf-b56e-d699b5ecd9d0")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();

        [Input(Guid = "755664f5-1ba5-4a83-9511-c54b5a407217")]
        public readonly InputSlot<SharpDX.Size2> Resolution = new InputSlot<SharpDX.Size2>();

        [Input(Guid = "e5355afa-0af0-4249-8309-a5ee1eb6dfdf")]
        public readonly InputSlot<int> States = new InputSlot<int>();

        [Input(Guid = "c14429eb-a9f3-493d-932e-a7ef78761676")]
        public readonly InputSlot<int> Neighbours = new InputSlot<int>();

        [Input(Guid = "7ad4fee4-5aa4-4648-aa58-8ae7aab96cdd")]
        public readonly InputSlot<int> RandomSeed = new InputSlot<int>();

        [Input(Guid = "cb33ba70-f5c5-4766-8d5b-48fe16fb04af")]
        public readonly InputSlot<bool> Reset = new InputSlot<bool>();

        [Input(Guid = "e04158d1-a693-4536-abed-29e799e2e03c")]
        public readonly InputSlot<int> SlowDown = new InputSlot<int>();

    }
}