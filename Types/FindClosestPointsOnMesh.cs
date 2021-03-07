using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_58afd953_d3fd_44a9_b54b_ccb287edc40c
{
    public class FindClosestPointsOnMesh : Instance<FindClosestPointsOnMesh>
    {

        [Output(Guid = "fdf76150-0448-470b-bf31-c3844f7b84f3")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Output = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "b9b7bda8-969d-413a-9446-b72a4c5864bb")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "603501a2-5581-47ca-a9e1-ab8e09fda1d8")]
        public readonly InputSlot<T3.Core.DataTypes.MeshBuffers> Mesh = new InputSlot<T3.Core.DataTypes.MeshBuffers>();
    }
}

