using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Win32;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Vector4 = SharpDX.Vector4;

namespace T3.Operators.Types.Id_a3bc1b8c_6bd9_4117_880e_afb9765e3104
{
    public class NoisePoints : Instance<NoisePoints>
    {
        [Output(Guid = "25c89e66-e8ee-4600-9d2f-009b7d9e75ca")]
        public readonly Slot<SharpDX.Vector4[]> Result = new Slot<SharpDX.Vector4[]>();

        public NoisePoints()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var count = Count.GetValue(context).Clamp(1, 10000);
            if (_points.Length != count)
                _points = new SharpDX.Vector4[count];

            var scale = Scale.GetValue(context);
            var frequency = Frequency.GetValue(context);
            var phase = Phase.GetValue(context);
            
            var amplitude = Amplitude.GetValue(context);
            var index = 0;
            var thickness = Thickness.GetValue(context);
            int seed = 1337;
            for (var x = 0; x < count; x++)
            {
                var fX = x / (float)count;
                _points[index] = new Vector4(
                                             MathUtils.PerlinNoise(phase +   0.234f + fX, frequency, 2, seed) * amplitude * scale.X,
                                             MathUtils.PerlinNoise(phase + 110.637f + fX, frequency, 2, seed) * amplitude * scale.Y,
                                             MathUtils.PerlinNoise(phase + 241.221f + fX, frequency, 2, seed) * amplitude * scale.Z,
                                             thickness);
                index++;
            }


            Result.Value = _points;
        }

        private SharpDX.Vector4[] _points = new Vector4[0];

        [Input(Guid = "52953760-435e-4f11-8e65-c9d46bc40076")]
        public readonly InputSlot<Vector3> Scale = new InputSlot<Vector3>();
        
        [Input(Guid = "7c35053c-bd51-421b-9a6d-ddb8c150abc9")]
        public readonly InputSlot<float> Frequency = new InputSlot<float>();

        [Input(Guid = "9D4E1103-94F6-49A0-A00E-07668EB708DF")]
        public readonly InputSlot<float> Amplitude = new InputSlot<float>();
        
        [Input(Guid = "2d2087bc-29a1-4b7f-909d-17d412fe1da5")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();
        
        [Input(Guid = "DEE89AD4-1516-40D0-A682-98E05A8B7C12")]
        public readonly InputSlot<float> Thickness = new InputSlot<float>();


        [Input(Guid = "cb697476-36df-44ae-bd1d-138cc49467c2")]
        public readonly InputSlot<int> Count = new InputSlot<int>();
    }
}