using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_1fec51bc_4de7_400a_8910_db39f4129579
{
    public class NumberPattern : Instance<NumberPattern>
    {
        [Output(Guid = "569ef449-6919-4e6f-880e-6f26c6fd2a5e")]
        public readonly Slot<SharpDX.Direct3D11.Texture2D> TextureOutput = new Slot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "8a3681fa-4820-4855-9a12-c3740772f4d8")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Texture = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "90620390-0fc4-4f2f-9c8f-04c6a75ee19e")]
        public readonly InputSlot<System.Numerics.Vector4> TextColor = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "79d612f0-0b6e-47a8-9e9b-ee2894c85cc8")]
        public readonly InputSlot<System.Numerics.Vector4> LineColor = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "dd187262-d769-4694-8ca4-a2c88a4667fd")]
        public readonly InputSlot<System.Numerics.Vector4> Highlight = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "3343385a-18eb-413e-a6b3-fe4d20a13260")]
        public readonly InputSlot<System.Numerics.Vector4> OriginalImage = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "2b0bf570-d839-4514-9e70-0956f4ffb8f7")]
        public readonly InputSlot<System.Numerics.Vector2> CellSize = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "72a70b15-0342-427a-8c2f-e02ef31b2677")]
        public readonly InputSlot<System.Numerics.Vector2> CellRange = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "fee40e14-e8b1-4bfa-abe1-9de7a6ed43f1")]
        public readonly InputSlot<System.Numerics.Vector2> Position = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "d4adfa55-97d8-4c42-a2fc-4c89f6c43c8f")]
        public readonly InputSlot<float> Offset = new InputSlot<float>();

        [Input(Guid = "8a123978-eca8-4059-8381-b0983ad74223")]
        public readonly InputSlot<float> ScrollOffset = new InputSlot<float>();

        [Input(Guid = "80ecefe9-adbf-4d12-a805-b3d41d667402")]
        public readonly InputSlot<float> ScrollSpeed = new InputSlot<float>();

        [Input(Guid = "34c56d90-6b8d-413e-9ced-68a8e7db3330")]
        public readonly InputSlot<float> HighlightThreshold = new InputSlot<float>();
    }
}

