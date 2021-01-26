﻿using System;
using System.Runtime.InteropServices;
using SharpDX;
using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Buffer = SharpDX.Direct3D11.Buffer;

namespace T3.Operators.Types.Id_fa45d013_5a1c_45a0_9b05_a4a4edfb06f9
{
    public class TypoGridBuffer : Instance<TypoGridBuffer>
    {
        [Output(Guid = "{6e6e8ce0-2b62-41f5-893d-9a20219faf82}")]
        public readonly Slot<SharpDX.Direct3D11.Buffer> Buffer = new Slot<SharpDX.Direct3D11.Buffer>();

        [Output(Guid = "{B8CF7AB8-BE34-4C0B-AFFC-CE09748FD6F1}")]
        public readonly Slot<int> VertexCount = new Slot<int>();

        public TypoGridBuffer()
        {
            Buffer.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var text = Text.GetValue(context);
            var bufferSize = BufferSize.GetValue(context);
            var wrapText = WrapText.GetValue(context);
            var textOffset = TextOffset.GetValue(context);
            
            var columns = bufferSize.Width;
            var rows = bufferSize.Height;
            if (columns <= 0 || rows <= 0)
                return;
            
            if ( string.IsNullOrEmpty(text))
                return;
            
            var textCycle = (int)textOffset.X + (int)(textOffset.Y) * columns;

            var size = rows * columns;
            if (_bufferContent == null || _bufferContent.Length != size)
            {
                _bufferContent = new BufferLayout[size];
            }
            
            var index = 0;

            char c;
            var highlightChars = HighlightCharacters.GetValue(context);
            
            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columns; columnIndex++)
                {
                    if (wrapText)
                    {
                        var i = (index + textCycle) % text.Length;
                        if (i < 0)
                            i += text.Length;
                        
                        c = text[i];
                    }
                    else
                    {
                        var i = index + textCycle;
                        var indexIsValid = i >= 0 && i < text.Length;
                        c = indexIsValid ? text[i] : ' ';
                    }

                    var highlight =  highlightChars.IndexOf(c) > -1 ? 1f : 0 ;    // oh, that's slow!
                    
                    _bufferContent[index] = new BufferLayout(
                                                             pos: new Vector2((float)columnIndex / columns, 1 - (float)rowIndex / rows),
                                                             uv: new Vector2(c % 16, (c >> 4)),
                                                             highlight: highlight); 

                    index++;
                }
            }
            
            ResourceManager.Instance().SetupStructuredBuffer(_bufferContent, ref Buffer.Value);
            Buffer.Value.DebugName = nameof(TypoGridBuffer);

            VertexCount.Value = size * 6;
        }

        private BufferLayout[] _bufferContent;

        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public struct BufferLayout
        {
            public BufferLayout(Vector2 pos, Vector2 uv, float highlight)
            {
                Pos = pos;
                Uv = uv;
                Highlight = highlight;
            }

            [FieldOffset(0)]
            public Vector2 Pos;
            
            [FieldOffset(2*4)]
            public Vector2 Uv;
            
            [FieldOffset(4*4)]
            public float Highlight;
        }       
        
        [Input(Guid = "86144B95-9272-4D02-A1A7-67C6544C3BB9")]
        public readonly InputSlot<float> Height = new InputSlot<float>();

        [Input(Guid = "00B52213-7D87-457A-8A17-F33D471CDAFE")]
        public readonly InputSlot<Size2> BufferSize = new InputSlot<Size2>();
        
        [Input(Guid = "E4AA7336-3D09-470E-B09C-352EFBC706F3")]
        public readonly InputSlot<System.Numerics.Vector2> CellSize = new InputSlot<System.Numerics.Vector2>();
        
        [Input(Guid = "92985EF6-B9C1-4892-BB76-C9CBAD69EC8A")]
        public readonly InputSlot<System.Numerics.Vector2> CellPadding = new InputSlot<System.Numerics.Vector2>();
        
        [Input(Guid = "E815D72E-1C71-42B7-A0A2-994C6E9F2954")]
        public readonly InputSlot<string> Text = new InputSlot<string>();
        
        [Input(Guid = "18B86E6A-3A7F-4FE4-9716-57AC19528CFD")]
        public readonly InputSlot<int> TextCycle = new InputSlot<int>();
        
        [Input(Guid = "1F34D82F-455E-4D6B-8C36-B058FBB5DE3D")]
        public readonly InputSlot<bool> WrapText = new InputSlot<bool>();
        
        [Input(Guid = "A9A4470C-980C-4FFF-936B-DA0D28584E02")]
        public readonly InputSlot<System.Numerics.Vector2> TextOffset = new InputSlot<System.Numerics.Vector2>();
        
        [Input(Guid = "DF1A4A1E-F1FB-4FB5-8416-422D224C3D23")]
        public readonly InputSlot<string> HighlightCharacters = new InputSlot<string>();

    }
}