using System;

using R5T.T0159;


namespace System
{
    public static class ITextOutputExtensions
    {
        /// <inheritdoc cref="ITextOutputOperations.WriteInformation(ITextOutput, string, object[])"/>
        public static void WriteInformation(this ITextOutput textOutput,
            string message,
            params object[] args)
        {
            Instances.TextOutputOperations.WriteInformation(textOutput,
                message,
                args);
        }

        /// <inheritdoc cref="ITextOutputOperations.WriteWarning_WithPause(ITextOutput, string, int, object[])"/>
        public static void WriteWarning_WithPause(this ITextOutput textOutput,
            string message,
            params object[] args)
        {
            Instances.TextOutputOperations.WriteWarning_WithPause(textOutput,
                message,
                2000,
                args);
        }

        public static void WriteSectionSeparator(this ITextOutput textOutput)
        {
            Instances.TextOutputOperator.WriteSectionSeparator(textOutput);
        }
    }
}
