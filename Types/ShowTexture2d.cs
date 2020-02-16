﻿using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b0212daa_7fba_4f6a_851c_3dd9e2e8a23e
{
    public class ShowTexture2d : Instance<ShowTexture2d>
    {
        [Output(Guid = "{996A44A6-005B-421F-85A4-A3CCA425044E}")]
        public readonly Slot<Texture2D> TextureOutput = new Slot<Texture2D>();

        public ShowTexture2d()
        {
            TextureOutput.UpdateAction = Update;
            TextureOutput.DirtyFlag.Trigger = DirtyFlagTrigger.Always;
        }

        private void Update(EvaluationContext context)
        {
            Command.GetValue(context);
            TextureOutput.Value = Texture.GetValue(context);
        }

        [Input(Guid = "{5A3E1FA0-21FC-4C2E-A4BB-45A311F24C00}")]
        public readonly InputSlot<Command> Command = new InputSlot<Command>();
        [Input(Guid = "{5095C803-FA2A-408C-AB56-8057E49648D5}")]
        public readonly InputSlot<Texture2D> Texture = new InputSlot<Texture2D>();
    }
}