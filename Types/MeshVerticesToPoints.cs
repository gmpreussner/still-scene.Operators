using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_2467e1ed_f7fc_4c90_8230_b80ba6b42a2d
{
    public class MeshVerticesToPoints : Instance<MeshVerticesToPoints>
    {

        [Output(Guid = "53089fc7-3f0b-46c4-81e1-04ecbb92efce")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> OutBuffer = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "e5ab7ae6-d8de-4c92-9130-1082e5a56ba1")]
        public readonly InputSlot<float> W = new InputSlot<float>();

        [Input(Guid = "b990cf29-00a5-4e39-8687-4502c7c7eebc")]
        public readonly InputSlot<T3.Core.DataTypes.MeshBuffers> Mesh = new InputSlot<T3.Core.DataTypes.MeshBuffers>();
    }
}

