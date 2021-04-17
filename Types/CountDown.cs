using System;
using System.Globalization;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Operators.Types.Id_9cb4d49e_135b_400b_a035_2b02c5ea6a72;

namespace T3.Operators.Types.Id_e4a38f3c_bd4c_406a_9979_bb683d79b39b
{
    public class CountDown : Instance<CountDown>
    {
        [Output(Guid = "511af1e0-9ada-46a2-8c14-0e18db506f95", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<string> Output = new Slot<string>();

        public CountDown()
        {
            Output.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var now = DateTime.Now;

            try
            {
                var targetTime = DateTime.Today;
                var launchTime = LaunchTime.GetValue(context);
                if(DateTime.TryParse(launchTime, out var d))
                {
                    targetTime = d;
                    //Log.Debug("date:" + d);
                }
                else
                {
                    Log.Warning($"invalid format for lauchTime '{launchTime}'");
                }
                //var v = Duration.GetValue(context);
                var duration = DateTime.Now - targetTime;
                
                
                var format = Format.GetValue(context);
                var outString = duration.ToString(format, CultureInfo.InvariantCulture);
                Output.Value = outString;
            }
            catch (System.FormatException)
            {
                //Log.Warning("Failed to format CountDown time: " + e.Message, SymbolChildId);
                Output.Value = "Invalid Format";
                return;
            }
        }

        [Input(Guid = "61E5281B-B772-4BBD-B52F-E6B6310D259A")]
        public readonly InputSlot<string> LaunchTime = new InputSlot<string>();

        [Input(Guid = "d404e744-fa84-4bc8-8aa3-e6e972d9a5a7")]
        public readonly InputSlot<string> Format = new InputSlot<string>();
    }
}