using System;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_6bb3fc41_f1d4_467e_afc6_62b452ec36be
{
    public class _AnalyseAudioRange : Instance<_AnalyseAudioRange>
    {
        [Output(Guid = "3cdc4645-2094-4e36-b06c-fa0ccf5ac890")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Output(Guid = "7181f674-8998-420b-a98b-094d22fdf174")]
        public readonly Slot<float> PulseLevel = new Slot<float>();

        [Output(Guid = "0b411b96-3907-45b3-9b2b-67f3b57668e5")]
        public readonly Slot<float> PeakCount = new Slot<float>();

        [Output(Guid = "a85d0955-a381-44f3-88e4-c2833c6219b2")]
        public readonly Slot<float> MovingSum = new Slot<float>();

        [Input(Guid = "b9befe9e-c11a-41c8-a127-410bd1681add")]
        public readonly InputSlot<System.Collections.Generic.List<float>> FFT = new InputSlot<System.Collections.Generic.List<float>>();

        [Input(Guid = "42412b35-6942-4802-8f12-b83bba66c830")]
        public readonly InputSlot<float> RangeMin = new InputSlot<float>();

        [Input(Guid = "2d64bab8-3560-4b2a-9dfa-643a1a4ba6f2")]
        public readonly InputSlot<float> RangeMax = new InputSlot<float>();

        [Input(Guid = "e3582ee9-ce77-4249-bbdd-21fb9196b44f")]
        public readonly InputSlot<float> Threshold = new InputSlot<float>();

        [Input(Guid = "f9004ee2-adc6-4d61-97c5-29c47b95281f")]
        public readonly InputSlot<float> MinTimeBetweenPeaks = new InputSlot<float>();

    }
}

