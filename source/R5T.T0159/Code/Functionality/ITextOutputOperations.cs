using System;

using Microsoft.Extensions.Logging;

using R5T.T0132;


namespace R5T.T0159
{
    [FunctionalityMarker]
    public partial interface ITextOutputOperations : IFunctionalityMarker
    {
        public void Log_Information(ITextOutput textOutput,
            string message,
            params object[] arguments)
        {
            // Log first in case we need to pause on the human output.
            textOutput.Logger.LogInformation(message, arguments);
        }

        /// <summary>
        /// Writes a message to both the logger and the human output.
        /// </summary>
        /// <param name="message"><inheritdoc cref="Documentation.ForMessageParam"/></param>
        /// <param name="arguments"><inheritdoc cref="Documentation.ForMessageArgumentsParam"/></param>
        public void WriteInformation(ITextOutput textOutput,
            string message,
            params object[] arguments)
        {
            // Log first in case we need to pause on the human output.
            textOutput.Logger.LogInformation(message, arguments);

            // The message format required for String.Format() is different than the structured logging string useful in logging.
            var formattedString = Instances.StringOperator.FormatStructuredString(
                message,
                arguments);

            textOutput.HumanOutput.WriteLine(formattedString);
        }

        /// <summary>
        /// Interpretting the message as a format string can cause problems (such as when the log message contains braces, i.e. '{' or '}').
        /// </summary>
        public void Write_Information_NoFormatting(
            ITextOutput textOutput,
            string message)
        {
            // Log first in case we need to pause on the human output.
            textOutput.Logger.LogInformation(message);

            textOutput.HumanOutput.WriteLine(message);
        }

        /// <summary>
        /// Writes a message to both the logger and the human output.
        /// </summary>
        /// <param name="message"><inheritdoc cref="Documentation.ForMessageParam"/></param>
        /// <param name="arguments"><inheritdoc cref="Documentation.ForMessageArgumentsParam"/></param>
        public void WriteWarning_WithPause(ITextOutput textOutput,
            string message,
            int pause_Milliseconds,
            params object[] arguments)
        {
            // Log first in case we need to pause on the human output.
            textOutput.Logger.LogInformation(message, arguments);

            // The message format required for String.Format() is different than the structured logging string useful in logging.
            var formattedString = Instances.StringOperator.FormatStructuredString(
                message,
                arguments);

            textOutput.HumanOutput.WriteLine_WithPause(
                formattedString,
                pause_Milliseconds);
        }
    }
}
