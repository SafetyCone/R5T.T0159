using System;

using Microsoft.Extensions.Logging;


namespace R5T.T0159.Extensions
{
    public static class ILoggerExtensions
    {
        public static ITextOutput ToTextOutput(this ILogger logger)
        {
            var textOutput = Instances.TextOutputOperator.FromLogger(logger);
            return textOutput;
        }
    }
}
