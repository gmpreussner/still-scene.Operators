using System.Numerics;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_74107b72_28d8_4350_9748_01d001e5f033
{
    public class RenderVolumeBox : Instance<RenderVolumeBox>
    {
        [Output(Guid = "da0d2f20-f771-4dc9-9734-57f230e073ec")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "2b5ee8f6-80c0-4143-b79e-3f7c7d07e4ed")]
        public readonly InputSlot<Vector4> Value = new InputSlot<Vector4>();

        [Input(Guid = "e7724445-1728-459d-bf1e-2d13063d5c97")]
        public readonly InputSlot<System.Numerics.Vector3> Size = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "80550ecb-6cc3-4cc6-8196-83490243d325")]
        public readonly InputSlot<T3.Core.DataTypes.Texture3dWithViews> VolumeData = new InputSlot<T3.Core.DataTypes.Texture3dWithViews>();

    }
}

