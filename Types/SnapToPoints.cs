using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_5822b0d8_32ed_4db3_975b_0e8fb8d7dd17
{
    public class SnapToPoints : Instance<SnapToPoints>
    {

        [Output(Guid = "d92815b8-4a13-4970-80ef-ef59858a43f6")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> OutBuffer = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "b663670f-f805-4c2e-8f05-e4ccb644ffad")]
        public readonly InputSlot<int> BlendMode = new InputSlot<int>();

        [Input(Guid = "1acfa764-f427-4cf5-b08c-81667d13feca")]
        public readonly InputSlot<float> BlendValue = new InputSlot<float>();

        [Input(Guid = "6f953ff7-0790-4ed6-9c25-c57b9d41a6da")]
        public readonly InputSlot<float> Distance = new InputSlot<float>();

        [Input(Guid = "8ba57792-f184-4f5f-a3c3-772e1f5fbe1d")]
        public readonly InputSlot<float> MaxAmount = new InputSlot<float>();

        [Input(Guid = "aeb6072f-4275-4822-a3e0-fb1f59615dd9")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> PointsA_ = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "1abba695-f044-459b-9c89-20441a32fa6b")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> PointsB_ = new InputSlot<T3.Core.DataTypes.BufferWithViews>();
    }
}

