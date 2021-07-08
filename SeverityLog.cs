using System;
using System.Collections.Generic;
using System.Text;

namespace GenericLoggingSystem
{
    public class SeverityLog : Log
    {
        public static int SourceMaxLength = 12;

        public string Source;
        public string Message;
        public Severity Severity = Severity.Info;
        public Exception Exception = null;

        public SeverityLog(string source, string message, Severity severity = Severity.Info, Exception e = null, bool autoExecute = true)
        {
            Source = source;
            Message = message;
            Severity = severity;
            Exception = e;

            //IMPORTANT CALL
            if (autoExecute) Execute();
        }

        public override void Execute()
        {
            base.Execute();
            if (Severity == Severity.Breaking) Environment.Exit(404);
        }

        public override string Serialize() 
        {
            return $"[{LogStream.TruncateString(Severity.ToString().ToUpper(), 8).PadRight(8)}] {GetTimeString()} {(Source.Length <= SourceMaxLength ? Source.PadRight(SourceMaxLength, ' ') : Source.Substring(0, SourceMaxLength))} {Message} {Exception}";
        }


    }

    /// <summary>
    /// Provides a format to filter and categorize your logs for easier debugging.
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// Informational Log
        /// </summary>
        Info,
        /// <summary>
        /// Warning log
        /// </summary>
        Warning,
        /// <summary>
        /// Error Log
        /// </summary>
        Error,
        /// <summary>
        /// Critical Log
        /// </summary>
        Critical,
        /// <summary>
        /// Breaking Log - <strong>WARNING: Log messages with this severity will exit the application.</strong>
        /// </summary>
        Breaking
    }
}
