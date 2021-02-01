using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_ab6ab34f_4c6e_41ef_af69_48bb9393651b
{
    public class PairPointsForLines : Instance<PairPointsForLines>
    {

        [Output(Guid = "943d1c32-e4e7-4502-8927-543b13ed0283")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> OutBuffer = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "b571a5e9-abec-47df-ac07-a7d1e60163d9")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GPoints = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "e14366ed-0591-424d-a8ab-36f8380dd614")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GTargets = new InputSlot<T3.Core.DataTypes.BufferWithViews>();
    }
}

