using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_ec8111b7_09d4_411e_9409_4e877d14371d
{
    public class PairPointsForGridWalkLines : Instance<PairPointsForGridWalkLines>
    {

        [Output(Guid = "066cbe56-b3f9-4b09-ba81-5cf1ee3d9206")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> OutBuffer = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "75d29a33-04a8-470f-a4ec-adfe738cbdc2")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> StartPoints = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "4da560cd-f799-4704-8084-09a3c9c15934")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> TargetPoints = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "fd68117b-58e2-434c-9540-420ad83a5a4f")]
        public readonly InputSlot<System.Numerics.Vector3> GridSize = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "ee8b0300-bc9f-4621-9515-f9edf69780d0")]
        public readonly InputSlot<System.Numerics.Vector3> GridOffset = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "2cba6d84-1c5d-4b91-8a23-7f93fe49f39c")]
        public readonly InputSlot<System.Numerics.Vector3> RandomizeGrid = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "0d9f5cc1-5aa1-4d2f-93f7-74baa1a0ded6")]
        public readonly InputSlot<float> StrokeLength = new InputSlot<float>();

        [Input(Guid = "d1665ede-b797-42a5-bf0b-bed4d8e14099")]
        public readonly InputSlot<float> Speed = new InputSlot<float>();

        [Input(Guid = "f698008a-22c1-4402-8aad-b4ebdd50cea3")]
        public readonly InputSlot<float> PhaseOffset = new InputSlot<float>();
    }
}

