using System;


namespace R5T.T0159.F000
{
    public class LoggingOperator : ILoggingOperator
    {
        #region Infrastructure

        public static ILoggingOperator Instance { get; } = new LoggingOperator();


        private LoggingOperator()
        {
        }

        #endregion
    }
}
