using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_0814a593_80ab_416f_a3ca_eef78b0a9c0c
{
    public class WrapPointPosition : Instance<WrapPointPosition>
    {

        [Output(Guid = "2889b8bf-5bb2-48f8-8fe0-02f95282c5f1")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> OutBuffer = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "dbe72c8b-6cc2-454b-83db-712f0cd4211c")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GPoints = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "fb569f81-c8d3-4330-8035-6bde4e0bd710")]
        public readonly InputSlot<System.Numerics.Vector3> Position = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "1d054b2e-1e1b-4899-a003-0d6e000d2d8d")]
        public readonly InputSlot<System.Numerics.Vector3> Size = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "8b09ea72-d6e8-444c-b20a-05133d846571")]
        public readonly InputSlot<bool> UseCameraPosition = new InputSlot<bool>();
    }
}

