using System;

using Microsoft.Extensions.Logging;

using R5T.T0158;


namespace R5T.T0159
{
    public class TextOutput : ITextOutput
    {
        public IHumanOutput HumanOutput { get; set; }
        public ILogger Logger { get; set; }
    }
}
