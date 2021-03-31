using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_1446e61e_7f68_4655_99c8_5be390f64851
{
    public class OrAll : Instance<OrAll>
    {
        [Output(Guid = "9B2B6339-EA13-4A8B-8223-1C95266E59F1")]
        public readonly Slot<bool> Result = new Slot<bool>();

        public OrAll()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var result = false;
            
            foreach (var input in Input.GetCollectedTypedInputs())
            {
                result |= input.GetValue(context);
            }
            
            Result.Value = result;
        }

        [Input(Guid = "374AD549-676B-4BD0-AE6A-421892B92BDB")]
        public readonly MultiInputSlot<bool> Input = new MultiInputSlot<bool>();
    }
}