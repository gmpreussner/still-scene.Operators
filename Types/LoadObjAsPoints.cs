using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.DataTypes;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Core.Rendering;
using Buffer = SharpDX.Direct3D11.Buffer;

namespace T3.Operators.Types.Id_ad651447_75e7_4491_a56a_f737d70c0522
{
    public class LoadObjAsPoints : Instance<LoadObjAsPoints>
    {
        // [Output(Guid = "02c14b5e-e187-4897-8163-85d2f6383c1c")]
        // public readonly Slot<BufferWithViews> VertexBuffer = new Slot<BufferWithViews>();
        //
        // [Output(Guid = "76ad9595-92ea-4fb1-a434-edb3e8834f7f")]
        // public readonly Slot<BufferWithViews> IndexBuffer = new Slot<BufferWithViews>();

        [Output(Guid = "2CAEEB72-F67D-4101-9A85-24AB8DEEB1C7")]
        public readonly Slot<StructuredList> Points = new Slot<StructuredList>();

        public LoadObjAsPoints()
        {
            Points.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var path = Path.GetValue(context);
            var mesh = ObjMesh.LoadFromFile(path);

            if (mesh == null)
            {
                Log.Warning($"Can't read file {path}");
                return;
            }

            //var pointCount = mesh.Vertices.Count;

            switch ((Modes)Mode.GetValue(context))
            {
                case Modes.AllVertices:
                {
                    //var list = new StructuredList<Point>(pointCount);
                    break;
                }
                case Modes.LinesVertices:
                {
                    try
                    {
                        int segmentCount = 0;
                        int vertexCount = 0;

                        int lastVertexIndex = -1;
                        foreach (var line in mesh.Lines)
                        {
                            vertexCount++;
                            if (line.V0 != lastVertexIndex)
                            {
                                segmentCount++;
                            }

                            lastVertexIndex = line.V2;
                        }

                        int countIncludingSeparators = vertexCount + segmentCount * 2;
                        _points = new StructuredList<Point>(countIncludingSeparators);

                        var pointIndex = 0;
                        lastVertexIndex = -1;
                        foreach (var line in mesh.Lines)
                        {
                            if (pointIndex > 0 && line.V0 != lastVertexIndex)
                            {
                                _points.TypedElements[pointIndex++] = new Point()
                                                                          {
                                                                              Position = new Vector3(
                                                                                                     mesh.Positions[lastVertexIndex].X,
                                                                                                     mesh.Positions[lastVertexIndex].Y,
                                                                                                     mesh.Positions[lastVertexIndex].Z),
                                                                              W = 1
                                                                          };
                                _points.TypedElements[pointIndex++] = Point.Separator();
                            }

                            _points.TypedElements[pointIndex++] = new Point()
                                                                      {
                                                                          Position = new Vector3(
                                                                                                 mesh.Positions[line.V0].X,
                                                                                                 mesh.Positions[line.V0].Y,
                                                                                                 mesh.Positions[line.V0].Z),
                                                                          W = 1
                                                                      };

                            lastVertexIndex = line.V2;
                        }
                        _points.TypedElements[pointIndex] = Point.Separator();
                        Log.Debug($"loaded {path} with {segmentCount} segments and {vertexCount} points");
                    }
                    catch (Exception e)
                    {
                        Log.Error("Reading vertices failed " + e);
                    }

                    break;
                }
            }

            Points.Value = _points;
        }

        private StructuredList<Point> _points = new StructuredList<Point>(0);

        enum Modes
        {
            AllVertices,
            LinesVertices,
            //WireframeLines, // Todo: Not implemented 
        }

        [Input(Guid = "895dab2c-e3be-4e73-9c96-0f6101cea113")]
        public readonly InputSlot<string> Path = new InputSlot<string>();

        [Input(Guid = "DCACD412-1885-4A10-B073-54192F074AE8", MappedType = typeof(Modes))]
        public readonly InputSlot<int> Mode = new InputSlot<int>();
    }
}