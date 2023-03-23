using System;


namespace R5T.T0159.F000
{
    public static class Instances
    {
        public static T0158.F000.IHumanOutputOperator HumanOutputOperator => T0158.F000.HumanOutputOperator.Instance;
        public static T0148.ILoggingOperator LoggingOperator => T0148.LoggingOperator.Instance;


        public class Internal
        {
            public static F000.Internal.ITextOutputOperator TextOutputOperator => F000.Internal.TextOutputOperator.Instance;
        }
    }
}