using System.Numerics;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_348652c3_abf5_4fe9_873b_89d1acaaf0ff
{
    public class Locator : Instance<Locator>
    {
        [Output(Guid = "357c4c25-2b08-4470-84b1-9707a3d8e56e", DirtyFlagTrigger = DirtyFlagTrigger.Always)]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Output(Guid = "7599cf50-cbb6-49ce-bb41-9f709b593b0b")]
        public readonly Slot<System.Numerics.Vector3> Pos = new Slot<System.Numerics.Vector3>();


        [Input(Guid = "53aeef4f-37f8-40a6-b552-cb35f5fb887c")]
        public readonly InputSlot<Vector3> Translation = new InputSlot<Vector3>();

        [Input(Guid = "43f63f2d-72f0-4d73-9311-fba7e4e32b31")]
        public readonly InputSlot<float> Size = new InputSlot<float>();

        [Input(Guid = "d7b88971-a4fb-4761-a2a2-0abeffd01552")]
        public readonly InputSlot<float> Thickness = new InputSlot<float>();

        [Input(Guid = "2a66b445-49c2-43fd-857f-71224d8bcb39")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "a6c523ba-4529-4a51-b6ce-69d396490625")]
        public readonly InputSlot<bool> EnableDepthTest = new InputSlot<bool>();

        [Input(Guid = "fc366e00-4980-4b3e-85a3-b83bff210458")]
        public readonly InputSlot<T3.Core.Operator.GizmoVisibility> Visibility = new InputSlot<T3.Core.Operator.GizmoVisibility>();

    }
}

