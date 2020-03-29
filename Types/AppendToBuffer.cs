using System;
using System.Text;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_7b21f10b_3548_4a23_95df_360addaeb03d
{
    public class AppendToBuffer : Instance<AppendToBuffer>
    {
        [Output(Guid = "8116d50e-0220-4bb7-b09d-881f722804cd")]
        public readonly Slot<System.Text.StringBuilder> Builder = new Slot<System.Text.StringBuilder>();

        public AppendToBuffer()
        {
            Builder.UpdateAction = Update;
            Builder.DirtyFlag.Trigger |= DirtyFlagTrigger.Always;
        }

        private void Update(EvaluationContext context)
        {
            var maxLength = MaxLength.GetValue(context);
            var stringBuilder = InputBuffer.GetValue(context);
            if (stringBuilder == null || maxLength <= 0) 
                return;

            if (Trigger.GetValue(context))
            {
                if (stringBuilder.Length < maxLength)
                {
                    stringBuilder.Append(String.GetValue(context));
                    stringBuilder.Append(Separator.GetValue(context));
                }
                else if(Fill.GetValue(context))
                {
                    var str = String.GetValue(context);
                    var sep = Separator.GetValue(context);
                    var ins = str + sep;
                    var insLength = ins.Length;
                    
                    var pos = _index % maxLength;
                    if (pos + insLength > maxLength)
                    {
                        insLength = maxLength - pos;
                    }

                    stringBuilder.Remove(pos, insLength);
                    stringBuilder.Insert(pos, ins);
                    _index += insLength;
                }
            }

            Builder.Value = stringBuilder;
        }

        private int _index = 0;

        [Input(Guid = "CCFAC8A9-0954-4869-A47C-B66C714F6545")]
        public readonly InputSlot<StringBuilder> InputBuffer = new InputSlot<StringBuilder>();

        [Input(Guid = "F834FB3B-D6F1-4FBE-974A-CFCD90FFDBA8")]
        public readonly InputSlot<string> String = new InputSlot<string>();

        [Input(Guid = "38CE7F47-C117-47A2-AEEA-609716C60555")]
        public readonly InputSlot<int> MaxLength = new InputSlot<int>();

        [Input(Guid = "095202BF-118F-4C4C-802E-7916BC290A60")]
        public readonly InputSlot<bool> Trigger = new InputSlot<bool>();

        [Input(Guid = "8EEE8067-1A4E-4372-93D0-2DBC368AA45A")]
        public readonly InputSlot<string> Separator = new InputSlot<string>();

        [Input(Guid = "B5027A5D-BA50-4BDC-8488-3F71B188FCBC")]
        public readonly InputSlot<bool> Fill = new InputSlot<bool>();
    }
}