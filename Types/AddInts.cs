using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_ab73a49e_c548_437d_a4ab_b3fa41e30097
{
    public class AddInts : Instance<AddInts>
    {
        [Output(Guid = "9B3E42F6-8980-4F30-8D8F-ED1DEA5F19B9")]
        public readonly Slot<int> Result = new Slot<int>();

//         [Output(Guid = "{DF114783-6C8D-47E2-99B0-8C97217657A5}")]
//         public readonly Slot<float> Result2 = new Slot<float>();

        public AddInts()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Result.Value = Input1.GetValue(context) + Input2.GetValue(context);
        }


        [Input(Guid = "8496877C-6186-4A9F-ACB2-CEB90026DC1D")]
        public readonly InputSlot<int> Input1 = new InputSlot<int>();

        [Input(Guid = "D5EFBE02-8F33-42E9-A205-859C218ACBEC")]
        public readonly InputSlot<int> Input2 = new InputSlot<int>();

//         [Input(Guid = "{D7478BAA-41B4-4F83-873B-6267AA93BFA9}")]
//         public readonly InputSlot<int> Input3 = new InputSlot<int>();
// 
//         [Input(Guid = "{99A53560-8F62-4240-9ED4-800525CF2EF3}")]
//         public readonly InputSlot<int> Input4 = new InputSlot<int>();
    }
}
