using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Numerics;
using Microsoft.Win32;
using SharpDX;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Quaternion = SharpDX.Quaternion;
using Vector4 = SharpDX.Vector4;

namespace T3.Operators.Types.Id_bdd982c4_dfc4_48d6_888a_f067081dbe8e
{
    public class MixPoints : Instance<MixPoints>
    {
        [Output(Guid = "5bf5f55e-9099-4413-b17a-f49d042cb4ca")]
        public readonly Slot<T3.Core.DataTypes.Point[]> Result = new Slot<T3.Core.DataTypes.Point[]>();

        public MixPoints()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            // var countX = CountX.GetValue(context).Clamp(1, 100);
            // var countY = CountY.GetValue(context).Clamp(1, 1);

            var listA = A.GetValue(context);
            var listB = B.GetValue(context);
            if (listA == null || listA.Length == 0 || listB == null || listB.Length == 0)
                return;

            var combination = (Combinations)Combination.GetValue(context);

            //var count = countX * countY;
            if (_points.Length != listA.Length)
                _points = new T3.Core.DataTypes.Point[listA.Length];

            var factor = Factor.GetValue(context);
            var mode = (Modes)Mode.GetValue(context);
            switch (combination)
            {
                case Combinations.Modulo:
                {
                    for (var index = 0; index < listA.Length; index++)
                    {
                        var pA = listA[index % listA.Length];
                        var pB = listB[index % listB.Length];

                        ComputeStep(index, pA, pB);
                    }
                    break;
                }
                case Combinations.Interpolate:
                {
                    float bStep = (float)listB.Length / (listA.Length-0.999f);

                    for (var index = 0; index < listA.Length; index++)
                    {
                        var pA = listA[index % listA.Length];
                        var bPointer = bStep * index;
                        var bIndex = (int)bPointer;
                        var fraction = bPointer - bIndex;
                        try
                        {
                            var pB1 = listB[bIndex < listB.Length - 1 ? bIndex  : listB.Length-1];
                            var pB2 = listB[bIndex < listB.Length - 2 ? bIndex + 1 : listB.Length - 1];
                            var pB = new T3.Core.DataTypes.Point()
                                         {
                                             Position =Vector4.Lerp(pB1.Position, pB2.Position, fraction),
                                             Orientation =  Quaternion.Identity,
                                         };
                            pB.Position.W = 1;
                            ComputeStep(index, pA, pB);
                        }
                        catch (Exception)
                        {
                            Log.Error("incorrect index calculation: \nindex: {index}  bIndex {bIndex}  fraction: {fraction}  lengthA:{listA.Length}  lengthB:{listB.Length}");
                        }
                    }
                    break;
                }
            }
            
            Result.Value = _points;

            void ComputeStep(int index, T3.Core.DataTypes.Point pA, T3.Core.DataTypes.Point pB)
            {
                switch (mode)
                {
                    case Modes.Add:
                        _points[index].Position = pA.Position + pB.Position;
                        break;

                    case Modes.Multiply:
                        _points[index].Position = pA.Position * pB.Position;
                        break;

                    case Modes.Blend:
                        _points[index].Position = Vector4.Lerp(pA.Position, pB.Position, factor);
                        break;
                }
            }
        }


        private const float Pi2 = (float)Math.PI * 2;
        private T3.Core.DataTypes.Point[] _points = new T3.Core.DataTypes.Point[0];

        enum Modes
        {
            Add,
            Multiply,
            Blend,
        }

        enum Combinations
        {
            Modulo,
            Interpolate,
        }
        
        [Input(Guid = "57F1D1D3-B437-4761-A5F5-0520CF820F58")]
        public readonly InputSlot<T3.Core.DataTypes.Point[]> A = new InputSlot<T3.Core.DataTypes.Point[]>();
        
        [Input(Guid = "3119875E-A6EA-4D19-B536-513459A0DB98")]
        public readonly InputSlot<T3.Core.DataTypes.Point[]> B = new InputSlot<T3.Core.DataTypes.Point[]>();
        
        [Input(Guid = "e8e8d26f-ccd1-4c15-b215-9c5bcfc133fb", MappedType = typeof(Modes))]
        public readonly InputSlot<int> Mode = new InputSlot<int>();

        [Input(Guid = "41BF7407-D81F-433C-9C73-41D2C831FE02")]
        public readonly InputSlot<float> Factor = new InputSlot<float>();

        [Input(Guid = "CACFC7CE-19AA-41B8-81FE-79E2D211C8F5", MappedType = typeof(Combinations))]
        public readonly InputSlot<int> Combination = new InputSlot<int>();

        
        // [Input(Guid = "6bcc7eb9-fd84-4eed-9817-ab43710425cf")]
        // public readonly InputSlot<Vector3> Start = new InputSlot<Vector3>();
        //
        // [Input(Guid = "49622fdc-a9eb-419c-8163-5a333e9dc543")]
        // public readonly InputSlot<float> StartW = new InputSlot<float>();
        //
        // [Input(Guid = "96dfec6b-fbc4-4fb8-86fd-99a3796c8866")]
        // public readonly InputSlot<Vector3> Scale = new InputSlot<Vector3>();
        //
        // [Input(Guid = "e020a2ba-3233-450a-a90b-39a47b8f0f7f")]
        // public readonly InputSlot<float> ScaleW = new InputSlot<float>();
        //
        // [Input(Guid = "64e29a9d-9510-49aa-9bb9-936a18bb69e1")]
        // public readonly InputSlot<int> CountX = new InputSlot<int>();
        //
        // [Input(Guid = "b6751ca8-438a-465c-839f-daee548d0e46")]
        // public readonly InputSlot<int> CountY = new InputSlot<int>();
    }
}