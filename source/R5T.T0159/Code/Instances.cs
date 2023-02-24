using System;


namespace R5T.T0159
{
    public static class Instances
    {
        public static T0158.IHumanOutputOperator HumanOutputOperator => T0158.HumanOutputOperator.Instance;
        public static F0000.IStringOperator StringOperator => F0000.StringOperator.Instance;
        public static ITextOutputOperations TextOutputOperations => T0159.TextOutputOperations.Instance;
        public static ITextOutputOperator TextOutputOperator => T0159.TextOutputOperator.Instance;
    }
}