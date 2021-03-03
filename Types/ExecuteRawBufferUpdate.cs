using System;
using SharpDX;
using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Buffer = SharpDX.Direct3D11.Buffer;

namespace T3.Operators.Types.Id_010aca02_263a_471c_b407_025b023f7f60
{
    public class ExecuteRawBufferUpdate : Instance<ExecuteRawBufferUpdate>
    {
        [Output(Guid = "DA3CD196-9454-438B-91B0-95486347902C")]
        public readonly Slot<Buffer> Output = new Slot<Buffer>();

        public ExecuteRawBufferUpdate()
        {
            Output.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            // This will execute the input
            UpdateCommands.GetValue(context);
            //if (command == null)
            //    return;

            
            var inputBuffer = Buffer.GetValue(context);
            //if (inputBuffer == null)
            //    return;

            Output.Value = inputBuffer;
            //Log.Debug("updating buffer " + inputBuffer);
        }

        [Input(Guid = "62AC9F97-1FCA-49F3-8FAC-F0A580C367BA")]
        public readonly InputSlot<Command> UpdateCommands = new InputSlot<Command>();
        
        [Input(Guid = "8D7ADBC1-0D55-47E0-93C5-42926AF00771")]
        public readonly InputSlot<Buffer> Buffer = new InputSlot<Buffer>();
    }
}