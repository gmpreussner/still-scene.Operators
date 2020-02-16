﻿using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_7a09136e_18b2_46b7_afff_8ef999e3965d
{
    public class ExecuteOnce : Instance<ExecuteOnce>
    {
        [Output(Guid = "5D73EBE6-9AA0-471A-AE6B-3F5BFD5A0F9C")]
        public readonly Slot<Command> Output = new Slot<Command>();

        public ExecuteOnce()
        {
            Output.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            if (Trigger.DirtyFlag.IsDirty)
            {
                Log.Info("ExecuteOnce triggered");
                Trigger.DirtyFlag.Clear();
                var commands = Command.GetCollectedTypedInputs();

                // do preparation if needed
                for (int i = 0; i < commands.Count; i++)
                {
                    commands[i].Value?.PrepareAction?.Invoke(context);
                }

                // execute commands
                for (int i = 0; i < commands.Count; i++)
                {
                    commands[i].GetValue(context);
                }

                // cleanup after usage
                for (int i = 0; i < commands.Count; i++)
                {
                    commands[i].Value?.RestoreAction?.Invoke(context);
                }
            }
        }

        [Input(Guid = "7450033D-5797-40C9-B6C4-B6E8D27FE501")]
        public readonly MultiInputSlot<Command> Command = new MultiInputSlot<Command>();
        [Input(Guid = "2049D44D-81A4-493B-A630-A1B273A4E6F9")]
        public readonly InputSlot<bool> Trigger = new InputSlot<bool>(true);
    }
}