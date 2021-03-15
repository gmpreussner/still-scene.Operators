using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_5e3648c0_3446_4f8f_b7ce_32d4a54b39de
{
    public class FollowMeshSurface : Instance<FollowMeshSurface>
    {

        [Output(Guid = "2be6338b-ed84-4720-8c73-dae4f115d8e6")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Output = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "715051f4-e326-46c4-a5a3-8265c69c12dd")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "0e7ec208-f050-4099-8ec0-205aaf41d8ab")]
        public readonly InputSlot<float> RestoreLayout = new InputSlot<float>();

        [Input(Guid = "fee83a79-8128-444f-812e-91f9851fca3a")]
        public readonly InputSlot<float> Speed = new InputSlot<float>();

        [Input(Guid = "0fff8aa4-b4ec-46af-aa9d-e4720afb6938")]
        public readonly InputSlot<float> SurfaceDistance = new InputSlot<float>();

        [Input(Guid = "271bdcd3-0544-4a40-9b7b-ed8234b35fef")]
        public readonly InputSlot<float> Spin = new InputSlot<float>();

        [Input(Guid = "4d78860a-be07-4e20-8c8d-61be14051f4d")]
        public readonly InputSlot<float> ScatterSurfaceDistance = new InputSlot<float>();

        [Input(Guid = "41cdd210-cca1-4cdf-afde-26403aeedaa7")]
        public readonly InputSlot<float> MaxSpeed = new InputSlot<float>();

        [Input(Guid = "7f47f780-7020-4c69-a5af-cab634bf23e8")]
        public readonly InputSlot<bool> Freeze = new InputSlot<bool>();

        [Input(Guid = "d13c53a9-3589-4a6b-985b-c2f622d93b3f")]
        public readonly InputSlot<bool> Reset = new InputSlot<bool>();

        [Input(Guid = "a3883c55-787e-47d2-ad69-2c2baf7ff546")]
        public readonly InputSlot<T3.Core.DataTypes.MeshBuffers> Mesh = new InputSlot<T3.Core.DataTypes.MeshBuffers>();
    }
}

