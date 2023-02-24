using System;


namespace R5T.T0159
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
