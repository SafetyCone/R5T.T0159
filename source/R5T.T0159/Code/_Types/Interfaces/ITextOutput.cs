using System;

using Microsoft.Extensions.Logging;

using R5T.T0142;
using R5T.T0158;


namespace R5T.T0159
{
    /// <summary>
    /// Allows output to both/either of an <see cref="IHumanOutput"/> instance and an <see cref="ILogger"/> instance.
    /// </summary>
    /// <remarks>
    /// There are two main ways that text can be output from an application:
    ///     1. Logging - Log everything so that you can tell later what happened, preferably to a file, but perhaps to the console (even though logging messages clutter up the console).
    ///     2. Human Output - Show only the "high points" of what the application is doing, or show status messages to reassure a human watching the console that the program is doing something.
    /// Instead of passing around two instances from function to function, or needing to create two contexts in which to run an action, bundle instances of each together.
    /// The bundle is also useful, since many messages will be <strong>both</strong> a log message and a human output message.
    /// </remarks>
    [UtilityTypeMarker]
    public interface ITextOutput
    {
        public IHumanOutput HumanOutput { get; }
        public ILogger Logger { get; }
    }
}
