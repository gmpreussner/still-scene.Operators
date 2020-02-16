using System;
using SharpDX;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_94a5de3b_ee6a_43d3_8d21_7b8fe94b042b
{
    public class Vector3FromFloat : Instance<Vector3FromFloat>
    {
        [Output(Guid = "AEDAEAD8-CCF0-43F0-9188-A79AF8D45250")]
        public readonly Slot<System.Numerics.Vector3> Result = new Slot<System.Numerics.Vector3>();

        public Vector3FromFloat()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Result.Value = new System.Numerics.Vector3(X.GetValue(context), Y.GetValue(context), Z.GetValue(context));
        }
        
        [Input(Guid = "084D5D0D-8FD4-431D-BF6C-8F082CCE1D3F")]
        public readonly InputSlot<float> X = new InputSlot<float>();

        [Input(Guid = "458891B9-0244-401A-B0A5-3A7EE365E7CB")]
        public readonly InputSlot<float> Y = new InputSlot<float>();
        
        [Input(Guid = "627F766E-056C-413E-8530-838D673BD031")]
        public readonly InputSlot<float> Z = new InputSlot<float>();
    }
}
