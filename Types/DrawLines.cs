using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Operators.Types.Id_fd9bffd3_5c57_462f_8761_85f94c5a629b;

namespace T3.Operators.Types.Id_836f211f_b387_417c_8316_658e0dc6e117
{
    public class DrawLines : Instance<DrawLines>
    {
        [Output(Guid = "73ebf863-ba71-421c-bee7-312f13c5eff0", DirtyFlagTrigger = DirtyFlagTrigger.Always)]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "e15b6dc7-aaf9-4244-a4b8-4ac13ee7d23f")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GPoints = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "75419a73-8a3e-4538-9a1d-e3b0ce7f8561")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "df158fcf-3042-48cf-8383-7bf4c1bcb8a6")]
        public readonly InputSlot<float> Size = new InputSlot<float>();

        [Input(Guid = "d0919481-203a-4379-8094-187d6209e00d")]
        public readonly InputSlot<float> ShrinkWithDistance = new InputSlot<float>();

        [Input(Guid = "c10f9c6c-9923-42c6-848d-6b98097acc67")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Texture_ = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "d90ff4e6-7d70-441f-a064-b40401025c36", MappedType = typeof(PickBlendMode.BlendModes))]
        public readonly InputSlot<int> BlendMod = new InputSlot<int>();

        [Input(Guid = "c9cf2182-1297-463c-b5c1-d4ee7ad0895c")]
        public readonly InputSlot<bool> EnableDepthWrite = new InputSlot<bool>();

        [Input(Guid = "092fc56a-65f8-425d-ae32-359839256a43")]
        public readonly InputSlot<int> UseWFor = new InputSlot<int>();

        [Input(Guid = "28f85ae9-ebae-4300-8aa0-738c6327cc44")]
        public readonly InputSlot<float> TransitionProgress = new InputSlot<float>();

        [Input(Guid = "9ba2aa59-e55b-4ebe-aa98-0f79ed77c7aa")]
        public readonly InputSlot<bool> EnableTest = new InputSlot<bool>();
    }
}

