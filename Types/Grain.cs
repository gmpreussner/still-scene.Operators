using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b5102fba_f05b_43fc_aa1d_613fe1d68ad2
{
    public class Grain : Instance<Grain>
    {
        [Output(Guid = "df388f27-f5b6-417b-87a7-a6a59b625128")]
        public readonly Slot<SharpDX.Direct3D11.Texture2D> TextureOutput = new Slot<SharpDX.Direct3D11.Texture2D>();


        [Input(Guid = "4525c76c-cdcf-47f3-aa96-335cfc5b5c1b")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Image = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "195da7e0-5279-4900-80cd-5635e96ab454")]
        public readonly InputSlot<float> Amount = new InputSlot<float>();

        [Input(Guid = "903c0270-dc46-402e-8088-8db8368a6dfb")]
        public readonly InputSlot<float> Color = new InputSlot<float>();

        [Input(Guid = "d24cce46-dd3f-4047-a33f-50abbca89cc4")]
        public readonly InputSlot<float> Exponent = new InputSlot<float>();

        [Input(Guid = "87a78859-5f0c-41af-8564-ac691b8f1950")]
        public readonly InputSlot<float> Brightness = new InputSlot<float>();

        [Input(Guid = "f1334f45-4335-4198-9b6e-ab9e8384aa32")]
        public readonly InputSlot<float> Speed = new InputSlot<float>();

        [Input(Guid = "edb719cd-be40-4758-9c13-98cf14d1a5c5")]
        public readonly InputSlot<float> Scale = new InputSlot<float>();

        [Input(Guid = "61bb0df6-6c8a-4f3a-b7f4-9d979377cab8")]
        public readonly InputSlot<SharpDX.Size2> Resolution = new InputSlot<SharpDX.Size2>();
    }
}

