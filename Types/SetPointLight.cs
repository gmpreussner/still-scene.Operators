using System.Numerics;
using System.Runtime.InteropServices;
using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_4912ba82_460a_4229_884d_6b647d64b08c
{
    public class SetPointLight : Instance<SetPointLight>
    {
        [Output(Guid = "d8c0cd0c-90e9-44fa-9f11-dda5a5b47239")]
        public readonly Slot<Command> Output = new Slot<Command>();

        public SetPointLight()
        {
            Output.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var pos = Position.GetValue(context);
            var intensity = Intensity.GetValue(context);
            var color = Color.GetValue(context);
            var range = Range.GetValue(context);
            
            var pointLights = context.PointLights;
            var light = new PointLight(pos, intensity, color, range);
            pointLights.Push(light);
            
            Command.GetValue(context); // Evaluate sub-tree
            
            pointLights.Pop();
        }

        [Input(Guid = "d46d2cb6-9ab9-4640-a3d4-e70e643bd3b4")]
        public readonly InputSlot<T3.Core.Command> Command = new InputSlot<T3.Core.Command>();

        [Input(Guid = "f46ed192-1f6c-415e-8fe3-6d4909859f6b")]
        public readonly InputSlot<System.Numerics.Vector3> Position = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "747e043b-39e9-420c-8314-b7d1ba5d61de")]
        public readonly InputSlot<float> Intensity = new InputSlot<float>();

        [Input(Guid = "7b77b6fb-e8bd-42a7-8fb9-5d411f9a0da6")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "e825e0b5-4c04-4ce6-9aef-7d099e9d2430")]
        public readonly InputSlot<float> Range = new InputSlot<float>();
        
    }
}