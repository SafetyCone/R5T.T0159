using System;

using R5T.T0142;


namespace R5T.T0159
{
    [DataTypeMarker]
    public interface IHasTextOutput
    {
        public ITextOutput TextOutput { get; }
    }
}
