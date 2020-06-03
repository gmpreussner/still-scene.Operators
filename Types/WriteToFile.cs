using System;
using System.IO;
using System.Net.Mime;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_0db15e2d_b457_44d7_bb58_ace0a0708073
{
    public class WriteToFile : Instance<WriteToFile>
    {
        [Output(Guid = "b5627217-63cf-49c6-b864-3f9af74b7a94")]
        public readonly Slot<string> Result = new Slot<string>();

        [Output(Guid = "D6234491-B051-4387-895A-6FA8C3C8AC37")]
        public readonly Slot<string> OutFilepath = new Slot<string>();

        public WriteToFile()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var content = Content.GetValue(context);
            var filepath = Filepath.GetValue(context);
            if (content != _lastContent)
            {
                try
                {
                    File.WriteAllText(filepath, content);
                }
                catch (Exception e)
                {
                    Log.Error($"Failed to write file {filepath}:" + e.Message);
                }
                
                _lastContent = content;
            }

            Result.Value = Content.GetValue(context);
            OutFilepath.Value = filepath;    // Forward so it can be triggered
        }

        private string _lastContent;
        
        
        [Input(Guid = "a12d0e5c-a0f9-4d3c-8ab6-827fb618c021")]
        public readonly InputSlot<string> Content = new InputSlot<string>();
        
        [Input(Guid = "DB4B08DA-9993-453A-A957-679637CDFD08")]
        public readonly InputSlot<string> Filepath = new InputSlot<string>();

    }
}