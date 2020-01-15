﻿using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Mathematics.Interop;
using T3.Core.Operator;

namespace T3.Operators.Types.Id_1f23db4a_871e_42a9_9255_49b956993eb1
{
    public class Viewport : Instance<Viewport>
    {
        [Output(Guid = "C543AF89-018E-4540-9F65-32CF6688CD42")]
        public readonly Slot<RawViewportF> Output = new Slot<RawViewportF>();

        public Viewport()
        {
            Output.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Output.Value = new RawViewportF
                           {
                               X = X.GetValue(context),
                               Y = Y.GetValue(context),
                               Width = Width.GetValue(context),
                               Height = Height.GetValue(context),
                               MinDepth = MinDepth.GetValue(context),
                               MaxDepth = MaxDepth.GetValue(context)
                           };
        }

        [Input(Guid = "65647489-4AD9-4D8C-8B4F-EEB726846488")]
        public readonly InputSlot<float> X = new InputSlot<float>();
        [Input(Guid = "33DA799A-EFF2-4E0A-9F8B-7F65CA03A350")]
        public readonly InputSlot<float> Y = new InputSlot<float>();
        [Input(Guid = "7A4DBBAC-B863-49D9-AD42-3F218683BCB1")]
        public readonly InputSlot<float> Width = new InputSlot<float>();
        [Input(Guid = "ACC2B98A-ED9F-4B7A-A274-480AF6F50335")]
        public readonly InputSlot<float> Height = new InputSlot<float>();
        [Input(Guid = "E378460F-44D2-4D73-97DE-34CCFACB11A3")]
        public readonly InputSlot<float> MinDepth = new InputSlot<float>();
        [Input(Guid = "4F926315-5826-42CD-B35F-48DB63E8D20E")]
        public readonly InputSlot<float> MaxDepth = new InputSlot<float>();
    }
}