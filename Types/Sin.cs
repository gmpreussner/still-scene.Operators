using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_6ab63114_6477_4ab2_a071_a66a64a6d2b9
{
    public class Sin : Instance<Sin>
    {
        [Output(Guid = "55D5C012-0026-4390-9B40-38BD1BBFDAD4")]
        public readonly Slot<float> Result = new Slot<float>();

        public Sin()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Result.Value = (float)Math.Sin(Input.GetValue(context) / Period.GetValue(context) + Phase.GetValue(context)) 
                           * Amplitude.GetValue(context) 
                           + Offset.GetValue(context);
        }
        
        [Input(Guid = "9C66D915-AF91-4ECD-955A-D9C15EF3EDDA")]
        public readonly InputSlot<float> Input = new InputSlot<float>();

        [Input(Guid = "3CB40A40-A0C3-4356-BDF3-778671FBD428")]
        public readonly InputSlot<float> Period = new InputSlot<float>();
        
        [Input(Guid = "08E659D8-4776-4449-BA62-53DAE590ACA8")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();

        [Input(Guid = "1319F4DC-45CC-46A5-8AAB-F4DFA93CC3DA")]
        public readonly InputSlot<float> Amplitude = new InputSlot<float>();
        
        [Input(Guid = "DDF69868-6AA8-474C-A4AE-105BBA6F120D")]
        public readonly InputSlot<float> Offset = new InputSlot<float>();
        

    }
}
