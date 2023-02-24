using System;


namespace R5T.T0159.F000
{
    public class TextOutputOperator : ITextOutputOperator
    {
        #region Infrastructure

        public static ITextOutputOperator Instance { get; } = new TextOutputOperator();


        private TextOutputOperator()
        {
        }

        #endregion
    }
}


namespace R5T.T0159.F000.Internal
{
    public class TextOutputOperator : ITextOutputOperator
    {
        #region Infrastructure

        public static ITextOutputOperator Instance { get; } = new TextOutputOperator();


        private TextOutputOperator()
        {
        }

        #endregion
    }
}
