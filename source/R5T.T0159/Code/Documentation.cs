using System;

using Microsoft.Extensions.Logging;


namespace R5T.T0159
{
	/// <summary>
	/// ITextOutput types library.
	/// </summary>
	public static class Documentation
	{
        /// <inheritdoc cref="LoggerExtensions.LogInformation(ILogger, EventId, Exception?, string?, object?[])" path="/param[@name='message']"/>
        public static readonly object ForMessageParam;

        /// <inheritdoc cref="LoggerExtensions.LogInformation(ILogger, EventId, Exception?, string?, object?[])" path="/param[@name='args']"/>
        public static readonly object ForMessageArgumentsParam;
    }
}