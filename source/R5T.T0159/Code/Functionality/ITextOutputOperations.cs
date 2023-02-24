using System;

using Microsoft.Extensions.Logging;

using R5T.T0132;


namespace R5T.T0159
{
    [FunctionalityMarker]
    public partial interface ITextOutputOperations : IFunctionalityMarker
    {
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
