using System.Numerics;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_63090462_3237_465e_a12c_25c8bbfaaa8c
{
    public class CASim2d : Instance<CASim2d>
    {

        [Output(Guid = "b4059e4a-8238-4f37-ab2d-d45d7853cff9")]
        public readonly Slot<SharpDX.Direct3D11.Texture2D> CABuffer2 = new Slot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "69b5c584-f365-469c-bf08-b1a125f7d757")]
        public readonly InputSlot<SharpDX.Size2> Resolution = new InputSlot<SharpDX.Size2>();

        [Input(Guid = "0f5159f9-7577-4e02-85f2-73f7566b897d")]
        public readonly InputSlot<int> States = new InputSlot<int>();

        [Input(Guid = "6374d267-e1a4-418e-8463-bba8a512708b")]
        public readonly InputSlot<int> Neighbours = new InputSlot<int>();

        [Input(Guid = "5f13eb52-23d4-4a47-b7cc-ea6ba74062ed")]
        public readonly InputSlot<int> RandomSeed = new InputSlot<int>();

        [Input(Guid = "1707a83c-bfab-40ef-af39-cc7249505a91")]
        public readonly InputSlot<bool> Reset = new InputSlot<bool>();

        [Input(Guid = "7c5feb4a-9611-46b0-af48-8675d4c618b9")]
        public readonly InputSlot<int> SlowDown = new InputSlot<int>();

        [Input(Guid = "3b633979-3ee0-4b09-a04e-6bf2287357f6")]
        public readonly InputSlot<float> Lambda = new InputSlot<float>();

        [Input(Guid = "546b5816-8783-4f1e-9907-0e8414e34606")]
        public readonly InputSlot<bool> Isotropic = new InputSlot<bool>();

        [Input(Guid = "7ce33028-ecd0-4e6b-b857-52eb8bbec9f4")]
        public readonly InputSlot<bool> ResetOnChange = new InputSlot<bool>();

    }
}