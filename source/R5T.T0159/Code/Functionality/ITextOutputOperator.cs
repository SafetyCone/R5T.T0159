using System;

using Microsoft.Extensions.Logging;

using R5T.T0132;


namespace R5T.T0159
{
    [FunctionalityMarker]
    public partial interface ITextOutputOperator : IFunctionalityMarker
    {
        public void WriteSectionSeparator(ITextOutput textOutput)
        {
            // Only write to the human output; logs files don't need this pretty formatting.
            textOutput.HumanOutput.WriteLine(
                Instances.Strings.TextDisplaySectionSeparator);
        }

        public TextOutput FromLogger(ILogger logger)
        {
            var humanOutput = Instances.HumanOutputOperator.NewNull();

            var textOutput = new TextOutput
            {
                HumanOutput = humanOutput,
                Logger = logger,
            };

            return textOutput;
        }
    }
}
