using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_179093f6_d3ef_43bc_a5af_1df2379ec081
{
    public class SwitchBlendState : Instance<SwitchBlendState>
    {
        [Output(Guid = "0608B46B-4778-4F95-B688-3A749F9664AE")]
        public readonly Slot<BlendState> Output = new Slot<BlendState>();

        public SwitchBlendState()
        {
            Output.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var blendStates = BlendStates.GetCollectedTypedInputs();
            var index = Index.GetValue(context);

            if (blendStates.Count == 0 || index == -1)
            {
                return;
            }
            
            index %= blendStates.Count;
            if (index < 0)
            {
                index += blendStates.Count;
            }
            
            Output.Value = blendStates[index].GetValue(context);
        }

        [Input(Guid = "A737BB60-D98B-4405-914C-7DF91A58D8BC")]
        public readonly MultiInputSlot<BlendState> BlendStates = new MultiInputSlot<BlendState>();
        
        [Input(Guid = "232a10e8-0357-4adc-935b-9cb1b7938730")]
        public readonly InputSlot<int> Index = new InputSlot<int>();
    }
}