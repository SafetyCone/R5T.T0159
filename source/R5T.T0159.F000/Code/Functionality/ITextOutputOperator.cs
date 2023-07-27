using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.T0159.F000
{
    [FunctionalityMarker]
    public partial interface ITextOutputOperator : IFunctionalityMarker
    {
        private static Internal.ITextOutputOperator Internal => F000.Internal.TextOutputOperator.Instance;


        public ITextOutput Get_New_Null()
        {
            var logger = Instances.LoggingOperator.GetNullLogger();

            var humanOutput = Instances.HumanOutputOperator.Get_New_Null();

            var output = new TextOutput
            {
                HumanOutput = humanOutput,
                Logger = logger,
            };

            return output;
        }

        public ITextOutput Get_Console()
        {
            var humanOutput = Instances.HumanOutputOperator.Get_Console();

            var logger = Instances.LoggingOperator.GetNullLogger();

            var output = new TextOutput
            {
                HumanOutput = humanOutput,
                Logger = logger,
            };

            return output;
        }

        public ITextOutput Get_TextOutput(
            string humanOutputTextFilePath,
            string logCategoryName,
            string logFilePath)
        {
            var humanOutput = Instances.HumanOutputOperator.GetCompositeHumanOutput_ConsoleAndFile(
                humanOutputTextFilePath);

            var logger = Instances.LoggingOperator.Get_Logger(
                logCategoryName,
                logFilePath);

            var textOutput = new TextOutput
            {
                HumanOutput = humanOutput,
                Logger = logger,
            };

            Internal.WriteLogFilePath(textOutput, logFilePath);

            return textOutput;
        }

        public void InTextOutputContext_Synchronous(
            string humanOutputTextFilePath,
            string logCategoryName,
            string logFilePath,
            Action<ITextOutput> textOutputAction)
        {
            Instances.HumanOutputOperator.InHumanOutputContext_Synchronous(
                humanOutputTextFilePath,
                humanOutput =>
                {
                    Instances.LoggingOperator.InFileLoggerContext_Synchronous(
                        logCategoryName,
                        logFilePath,
                        logger =>
                        {
                            var textOutput = new TextOutput
                            {
                                HumanOutput = humanOutput,
                                Logger = logger,
                            };

                            Internal.WriteLogFilePath(textOutput, logFilePath);

                            textOutputAction(textOutput);
                        });
                });
        }

        public (
            string humanOutputTextFilePath,
            string logFilePath)
        InTextOutputContext_Synchronous(
            Func<string> humanOutputTextFilePathProvider,
            string logCategoryName,
            Func<string> logFilePathProvider,
            Action<ITextOutput> textOutputAction)
        {
            var humanOutputTextFilePath = humanOutputTextFilePathProvider();

            var logFilePath = logFilePathProvider();

            this.InTextOutputContext_Synchronous(
                humanOutputTextFilePath,
                logCategoryName,
                logFilePath,
                textOutputAction);

            return (humanOutputTextFilePath, logFilePath);
        }

        public Task InTextOutputContext(
            string humanOutputTextFilePath,
            string logCategoryName,
            string logFilePath,
            Func<ITextOutput, Task> textOutputAction)
        {
            return Instances.HumanOutputOperator.InHumanOutputContext(
                humanOutputTextFilePath,
                humanOutput =>
                {
                    return Instances.LoggingOperator.InFileLoggerContext(
                        logCategoryName,
                        logFilePath,
                        logger =>
                        {
                            var textOutput = new TextOutput
                            {
                                HumanOutput = humanOutput,
                                Logger = logger,
                            };

                            Internal.WriteLogFilePath(textOutput, logFilePath);

                            return textOutputAction(textOutput);
                        });
                });
        }

        public async Task<(
            string humanOutputTextFilePath,
            string logFilePath)>
        InTextOutputContext(
            Func<string> humanOutputTextFilePathProvider,
            string logCategoryName,
            Func<string> logFilePathProvider,
            Func<ITextOutput, Task> textOutputAction)
        {
            var humanOutputTextFilePath = humanOutputTextFilePathProvider();

            var logFilePath = logFilePathProvider();

            await this.InTextOutputContext(
                humanOutputTextFilePath,
                logCategoryName,
                logFilePath,
                textOutputAction);

            return (humanOutputTextFilePath, logFilePath);
        }
    }
}


namespace R5T.T0159.F000.Internal
{
    [FunctionalityMarker]
    public partial interface ITextOutputOperator : IFunctionalityMarker
    {
        public void WriteLogFilePath(ITextOutput textOutput,
            string logFilePath)
        {
            textOutput.HumanOutput.WriteLine($"Log file path:\n\t{logFilePath}");
        }
    }
}