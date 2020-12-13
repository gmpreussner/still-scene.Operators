using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_cf3268d7_4f3d_47bd_8cb5_0214c75432ec 
{
    public class ModInt : Instance<ModInt>
    {
        [Output(Guid = "8FED46E4-B9DF-4D56-B098-9C9A17775139")]
        public readonly Slot<int> Result = new Slot<int>();

        public ModInt()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var v = Value.GetValue(context);
            var mod = Mod.GetValue(context);
            if (mod == 0)
                return;
            
            Result.Value = v % mod;
        }
        
        [Input(Guid = "3528F4D3-3529-4551-9DC1-E1DAFE6B0669")]
        public readonly InputSlot<int> Value = new InputSlot<int>();

        [Input(Guid = "CCDEA113-C046-4EC2-B1FB-30D6E15DB7CE")]
        public readonly InputSlot<int> Mod = new InputSlot<int>();
    }
}
