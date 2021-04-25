using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b5515341_24ef_48ff_b832_d40e8189c6a4
{
    public class ReflectionLines : Instance<ReflectionLines>
    {

        [Output(Guid = "d4437c90-9a13-4f35-a83f-b27dde3c4681")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> OutBuffer = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "57917b87-9aa4-416b-8417-fc2ac9e849b0")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GPoints = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "517fa007-bf56-497f-be87-2574ff9125c6")]
        public readonly InputSlot<T3.Core.DataTypes.MeshBuffers> Mesh = new InputSlot<T3.Core.DataTypes.MeshBuffers>();

        [Input(Guid = "25c7cc14-9422-4f47-b996-0e7d4ff0de69")]
        public readonly InputSlot<int> StepCount = new InputSlot<int>();

        [Input(Guid = "79d4a70d-c427-44fc-b917-646d71cd9647")]
        public readonly InputSlot<float> DecayW = new InputSlot<float>();

        [Input(Guid = "0af5f073-eb2b-4654-af69-2de7edc526e1")]
        public readonly InputSlot<float> ExtendSteps = new InputSlot<float>();
    }
}

