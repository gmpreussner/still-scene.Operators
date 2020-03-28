using System;
using System.Text;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_c5f1292a_e692_422b_9261_b5ae3451cd7c 
{
    public class BufferToString : Instance<BufferToString>
    {
        [Output(Guid = "71C4AA96-9A20-494A-9A28-6DD33A867ED2")]
        public readonly Slot<string> String = new Slot<string>();
        
        public BufferToString()
        {
            String.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var stringBuilder = InputBuffer.GetValue(context);
            if (stringBuilder == null)
            {
                String.Value = System.String.Empty;    
                return;
            }
            
            String.Value = stringBuilder.ToString();
        }
        
        [Input(Guid = "4690405C-343C-4F4B-BF32-51F5D2CC9C76")]
        public readonly InputSlot<StringBuilder> InputBuffer = new InputSlot<StringBuilder>();
        
    }
}
