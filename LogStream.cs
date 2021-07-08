using System;
using System.IO;
using System.Reflection;

namespace GenericLoggingSystem
{
    public static class LogStream
    {
        private static bool isInitialized = false;
        private static string logFilePath;


        internal static void WriteLog(string logText)
        {
            if(!isInitialized) throw new Exception("LogStream not initialized. Please call static method \"LogStream.Initialize()\".");

            Console.WriteLine(logText);


            DateTime now = DateTime.Now;
            using (StreamWriter sw = File.AppendText(logFilePath + $"/{now.Month:00}-{now.Day:00}-{now.Year}.log"))
                sw.WriteLine(logText);
        }

        public static string TruncateString(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        /// <summary>
        /// <para>Initializes the LogStream for use in your project.</para> 
        /// </summary>
        /// <remarks>
        /// Log files will appear in <code>{ExecutableDirectory}/Logs/</code><br/>
        /// You can use the <see cref="LogStream.Initialize(string, bool)" /> if you want a custom LogDirectory.
        /// </remarks>
        public static void Initialize() => Initialize(AppDomain.CurrentDomain.BaseDirectory + "/Logs");


        /// <summary>
        /// Initializes the LogStream for use in your project.
        /// </summary>
        /// <param name="logFileDirectory">Directory the log files will be created in.</param>
        /// <param name="createDirectoryIfNotExists">Should we handle the creation of the directory if it does not exist?</param>
        public static void Initialize(string logFileDirectory, bool createDirectoryIfNotExists = true)
        {
            //check if directory is valid
            if (createDirectoryIfNotExists) Directory.CreateDirectory(logFileDirectory);
            else if (!Directory.Exists(logFileDirectory)) throw new Exception($"Directory '{logFileDirectory}' does not exist!");

            logFilePath = logFileDirectory;

            //notify we have been initialized
            isInitialized = true;
        }


        public static void Log(string source, string message)
        {

        }
    }
}
