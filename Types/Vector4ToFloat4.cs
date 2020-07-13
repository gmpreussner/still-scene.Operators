using System;
using System.Numerics;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b15e4950_5c72_4655_84bc_c00647319030
{
    public class Vector4ToFloat4 : Instance<Vector4ToFloat4>
    {
        [Output(Guid = "CFB58526-0053-4BCA-AA85-D83823EFBA96")]
        public readonly Slot<float> X = new Slot<float>();
        [Output(Guid = "2F8E90DD-BA03-43DC-82A2-8D817DF45CC7")]
        public readonly Slot<float> Y = new Slot<float>();
        [Output(Guid = "162BB4FE-3C59-45C2-97CC-ECBA85C1B275")]
        public readonly Slot<float> Z = new Slot<float>();
        [Output(Guid = "E1DEDE5F-6963-4BCC-AA12-ABEB819BB5DA")]
        public readonly Slot<float> W = new Slot<float>();

        public Vector4ToFloat4()
        {
            X.UpdateAction = Update;
            Y.UpdateAction = Update;
            Z.UpdateAction = Update;
            W.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Vector4 value = Value.GetValue(context);
            X.Value = value.X;
            Y.Value = value.Y;
            Z.Value = value.Z;
            W.Value = value.W;
        }
        
        [Input(Guid = "980EF785-6AE2-44D1-803E-FEBFC75791C5")]
        public readonly InputSlot<System.Numerics.Vector4> Value = new InputSlot<Vector4>();
    }
}
