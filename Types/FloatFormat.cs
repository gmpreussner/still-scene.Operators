﻿using System.Globalization;
using T3.Core.Operator;

namespace T3.Operators.Types.Id_39c96cfd_dedf_4f76_a471_d1c26c9ba9fa
{
    public class FloatFormat : Instance<FloatFormat>
    {
        [Output(Guid = "{C63A1977-A594-490D-B5FB-DE4D40BAD016}")]
        public readonly Slot<string> Output = new Slot<string>();

        public FloatFormat()
        {
            Output.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var v = Value.GetValue(context);
            var s = Format.GetValue(context);
            try
            {
                Output.Value = string.IsNullOrEmpty(s) ? v.ToString(CultureInfo.InvariantCulture) : string.Format(CultureInfo.InvariantCulture, s, v);
            }
            catch (System.FormatException)
            {
                Output.Value = "Invalid Format";
            }
        }

        [Input(Guid = "{F36E4078-2608-4308-AB5F-077C05B1181A}")]
        public readonly InputSlot<float> Value = new InputSlot<float>();

        [Input(Guid = "{B2B32C44-62D8-4ACB-A9A7-4856EC7A33BB}")]
        public readonly InputSlot<string> Format = new InputSlot<string>();
    }
}