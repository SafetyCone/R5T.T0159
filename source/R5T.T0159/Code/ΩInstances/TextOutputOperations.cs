using System;


namespace R5T.T0159
{
    public class TextOutputOperations : ITextOutputOperations
    {
        #region Infrastructure

        public static ITextOutputOperations Instance { get; } = new TextOutputOperations();


        private TextOutputOperations()
        {
        }

        #endregion
    }
}
