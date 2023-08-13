using System;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using R5T.T0132;
using R5T.T0159;


namespace R5T.T0159
{
    [FunctionalityMarker]
    public partial interface ITextOutputOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Uses the <see cref="NullLogger.Instance"/> and <see cref="TextOutput.Null"/> singleton instances
        /// to create a new text output instance.
        /// <para>Useful for supplying default instances for method overloads that need a text output, but were not initially designed with one.</para>
        /// </summary>
        public ITextOutput Get_New_Null()
        {
            var humanOutput = Instances.HumanOutputOperator.Get_Null();

            var logger = Instances.LoggingOperator.Get_NullLogger();

            var output = new TextOutput
            {
                HumanOutput = humanOutput,
                Logger = logger,
            };

            return output;
        }

        public void WriteSectionSeparator(ITextOutput textOutput)
        {
            // Only write to the human output; logs files don't need this pretty formatting.
            textOutput.HumanOutput.WriteLine(
                Instances.Strings.TextDisplaySectionSeparator);
        }

        public TextOutput FromLogger(ILogger logger)
        {
            var humanOutput = Instances.HumanOutputOperator.Get_New_Null();

            var textOutput = new TextOutput
            {
                HumanOutput = humanOutput,
                Logger = logger,
            };

            return textOutput;
        }

        public TextOutput FromNullLogger()
        {
            return this.FromLogger(
                Microsoft.Extensions.Logging.Abstractions.NullLogger.Instance);
        }
    }
}
