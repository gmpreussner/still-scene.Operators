using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_3737cd30_c79a_4282_897a_7d2a44076c65
{
    public class OffsetPoints : Instance<OffsetPoints>
    {

        [Output(Guid = "5a0777ae-9dff-4c8f-b206-eac6d65a910f")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Output = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "4b7cc2cc-8f7b-4460-8beb-8a4eea101ef6")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "a17861cd-41e8-4cbb-9119-74e091bf4de1")]
        public readonly InputSlot<System.Numerics.Vector3> Direction = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "eb6318b0-619e-47ef-ae3b-fc760137f306")]
        public readonly InputSlot<float> Distance = new InputSlot<float>();
    }
}

