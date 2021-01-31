using System.Collections.Generic;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using System;

namespace T3.Operators.Types.Id_d3a19896_230f_458f_b4ba_e448f63f0d51
{
    public class SumRange : Instance<SumRange>
    {
        [Output(Guid = "3bfdd07b-8212-424d-b449-f7b87551410f")]
        public readonly Slot<float> Selected = new Slot<float>();

        public SumRange()
        {
            Selected.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var list = Input.GetValue(context);
            if (list == null || list.Count == 0)
            {
                return;
            }
            var lowerLimit = Math.Max(0, LowerLimit.GetValue(context));
            var upperLimit = Math.Min(list.Count, UpperLimit.GetValue(context));
            var sum = 0f;
            for (var index = lowerLimit; index < upperLimit; index++) {
                sum += list[index];
            }
            Selected.Value = sum;
        }


        [Input(Guid = "865d1fd4-b225-4651-bc01-c43f071b8b42")]
        public readonly InputSlot<int> LowerLimit = new InputSlot<int>(0);
        
        [Input(Guid = "646E17F6-5A98-42C7-8D3B-26CCB02D3E68")]
        public readonly InputSlot<int> UpperLimit = new InputSlot<int>(0);
        
        [Input(Guid = "056eba13-3ea9-4d0f-a45d-fce1ffaf403c")]
        public readonly InputSlot<List<float>> Input = new InputSlot<List<float>>(new List<float>(20));
    }
}