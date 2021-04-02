using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_d14233a2_8240_47d3_bb92_0854f6d3b218
{
    public class DustParticles : Instance<DustParticles>
    {
        [Output(Guid = "846bc771-7367-48e2-8389-206e2ee5c063")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "df0a84c2-a1e9-492f-903a-5ef7511c6ec8")]
        public readonly InputSlot<int> Count = new InputSlot<int>();

        [Input(Guid = "e92432c8-6ceb-494b-9cf4-b21191567b29")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "70f0f867-a4de-44da-b8e3-a7e95e1740a3")]
        public readonly InputSlot<float> Size = new InputSlot<float>();

        [Input(Guid = "c42d8124-d656-4b52-864f-9c9d888e0c54")]
        public readonly InputSlot<float> WrapSize = new InputSlot<float>();

        [Input(Guid = "0744e03b-9df3-4a5e-9cfa-f522d9d946ea")]
        public readonly InputSlot<float> NoiseAmount = new InputSlot<float>();

        [Input(Guid = "10fa40ee-c6f6-4f6b-bf70-54eeb4c11891")]
        public readonly InputSlot<float> NoiseFrequency = new InputSlot<float>();

        [Input(Guid = "3783617d-17d5-4052-b732-60c61948ca1f")]
        public readonly InputSlot<float> NoiseVariation = new InputSlot<float>();

        [Input(Guid = "cee8f890-4ea3-4f58-9940-156c93c7bc1f")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();

        [Input(Guid = "bafd96cc-c886-4392-8f57-592cb8651181")]
        public readonly InputSlot<int> TrailLength = new InputSlot<int>();

        [Input(Guid = "fd8340d5-b604-4605-9c3a-a57477d85919")]
        public readonly InputSlot<System.Numerics.Vector4> TrailColor = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "31cfdca2-7f14-4c88-93ca-6f160829ca78")]
        public readonly InputSlot<float> TrailWidth = new InputSlot<float>();

        [Input(Guid = "f084ae44-d69a-48c3-936b-b89e310ca185")]
        public readonly InputSlot<bool> Reset = new InputSlot<bool>();

        [Input(Guid = "9ef1f3f7-da31-408b-b563-7d6c089278c7")]
        public readonly InputSlot<System.Numerics.Vector3> Gravity = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "e3a995dc-ec77-439c-8aed-e47df5e2b923")]
        public readonly InputSlot<System.Numerics.Vector3> OffsetVolume = new InputSlot<System.Numerics.Vector3>();


    }
}

