using System;
using System.Text;
using SharpDX;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_bf76bc78_74e1_45c3_9c67_de50262a48ae 
{
    public class ScrambleBuffer : Instance<ScrambleBuffer>
    {
        [Output(Guid = "f460db31-2603-4468-ac68-d1a3b93c41da", DirtyFlagTrigger = DirtyFlagTrigger.Always)]
        public readonly Slot<System.Text.StringBuilder> Builder = new Slot<System.Text.StringBuilder>();

        
        public ScrambleBuffer()
        {
            Builder.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var stringBuilder = InputBuffer.GetValue(context);
            Builder.Value = stringBuilder;
            if (stringBuilder == null)
                return;

            var bufferLength = stringBuilder.Length;
            if (TriggerChop.GetValue(context))
            {
                //if (stringBuilder.Length < MaxLength.GetValue(context))
                //    stringBuilder.Append(String.GetValue(context));
                var minRandomLength = MinLength.GetValue(context);
                if (minRandomLength < 0)
                    minRandomLength = 0;

                var maxRandomLength = MaxLength.GetValue(context);
                if (maxRandomLength < minRandomLength)
                    maxRandomLength = minRandomLength;
            
                var lenRemove = (int)_random.NextLong(minRandomLength, maxRandomLength);

                var maxRandPos = bufferLength - lenRemove;
                if (maxRandPos < 0)
                    maxRandPos = 0;
            
                var randPos = (int)_random.NextLong(0, maxRandPos);
                if (lenRemove > 0 &&  lenRemove < bufferLength)
                    stringBuilder.Remove(randPos, lenRemove);
            }
            
            var fillString = FillString.GetValue(context);
            bufferLength = stringBuilder.Length;
            if (TriggerFill.GetValue(context) && fillString.Length > 0 && bufferLength > 0)
            {
                if (TriggerFillJump.GetValue(context))
                {
                    _fillIndex = (int)_random.NextLong(0, bufferLength);
                }
                _fillIndex+= FillDirection.GetValue(context);
                _fillIndex %= bufferLength;
                if (_fillIndex < 0)
                    _fillIndex += bufferLength;
                
                stringBuilder[_fillIndex] = fillString[_fillIndex % fillString.Length];
            }
        }

        private readonly Random _random = new Random();
        private int _fillIndex = 0;
        
        [Input(Guid = "c80a289a-e0d5-459f-b79e-fff72757b416")]
        public readonly InputSlot<StringBuilder> InputBuffer = new InputSlot<StringBuilder>();

        [Input(Guid = "2A078B1D-0115-467F-8625-6D36EF2FDAF9")]
        public readonly InputSlot<int> MinLength = new InputSlot<int>();

        [Input(Guid = "7e68d5fd-f9be-4f23-bc1b-0bdb72e63137")]
        public readonly InputSlot<int> MaxLength = new InputSlot<int>();
        
        [Input(Guid = "B5DEEFF1-7188-4742-A438-CB3CE1AFDE59")]
        public readonly InputSlot<bool> TriggerChop = new InputSlot<bool>();

        [Input(Guid = "AA458C22-A874-4200-AF62-0DA94D82631F")]
        public readonly InputSlot<bool> TriggerFill = new InputSlot<bool>();

        [Input(Guid = "262511B2-3A96-4600-8325-0FE84568B42F")]
        public readonly InputSlot<bool> TriggerFillJump = new InputSlot<bool>();

        [Input(Guid = "EB856F4F-2B57-40CC-BF7E-EE6BFC955F34")]
        public readonly InputSlot<string> FillString = new InputSlot<string>();
        
        [Input(Guid = "10A1209A-15F1-42AC-B105-2CCBC0F4FF4D")]
        public readonly InputSlot<int> FillDirection = new InputSlot<int>();

    }
}
