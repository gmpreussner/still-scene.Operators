﻿using System;
using System.Text;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_48ab9824_76ca_4238_800f_9cf95311e6c0
{
    public class StringConcat : Instance<StringConcat>
    {
        [Output(Guid = "{E47BF25E-351A-44E6-84C6-AD3ABC93531A}")]
        public readonly Slot<string> Result = new Slot<string>();

        public StringConcat()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            _stringBuilder.Clear();
            var separator = Separator.GetValue(context);

            var isFirst = true;
            foreach (var input in Input.GetCollectedTypedInputs())
            {
                if (!isFirst && !string.IsNullOrEmpty(separator))
                    _stringBuilder.Append(separator);

                var t = input.GetValue(context);
                if(!string.IsNullOrEmpty(t))
                    _stringBuilder.Append(t);
                
                isFirst = false;
            }
            Result.Value = _stringBuilder.ToString();
        }

        private readonly StringBuilder _stringBuilder = new StringBuilder();

        [Input(Guid = "{B5E72715-9339-484F-B197-5A28CD823798}")]
        public readonly MultiInputSlot<string> Input = new MultiInputSlot<string>();
        
        [Input(Guid = "C832BA89-F4AE-4C47-B62B-52DA52A09556")]
        public readonly InputSlot<string> Separator = new InputSlot<string>();

    }
}