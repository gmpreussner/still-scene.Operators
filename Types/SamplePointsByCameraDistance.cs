using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_0f40e5e5_e406_4f87_854b_fbdd670b5504
{
    public class SamplePointsByCameraDistance : Instance<SamplePointsByCameraDistance>
    {

        [Output(Guid = "7aeca2d3-c8aa-421f-91df-5a9df06a3040")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Output = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "57b87561-626c-44a9-ac81-393ede887c67")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "f03533f6-eec4-4cce-9736-b751322efa26")]
        public readonly InputSlot<float> NearRange = new InputSlot<float>();

        [Input(Guid = "a7f46f47-4cc1-4d62-ae23-46b12aa44eea")]
        public readonly InputSlot<float> FarRange = new InputSlot<float>();

        [Input(Guid = "4b41cfe4-303e-4748-a585-45babdf18e0e")]
        public readonly InputSlot<T3.Core.Animation.Curve> WForDistance = new InputSlot<T3.Core.Animation.Curve>();
    }
}

