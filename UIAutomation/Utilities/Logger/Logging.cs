namespace UIAutomation.Utilities.Logger
{
    using System;
    using System.IO;
    using System.Reflection;
    public class Logging
    {
        private static readonly object ObectToLock = new object();

        /// <summary>
        /// Custom logging level enum
        /// </summary>
        public enum LogLevel
        {
            INFO,
            DEBUG,
            ERROR,
            TRACE
        }

        /// <summary>
        /// Debug logging
        /// </summary>
        /// <param name="text">text to write</param>
        public static void Debug(string text)
        {
            WriteLog(text, LogLevel.DEBUG);
        }

        /// <summary>
        /// Error logging
        /// </summary>
        /// <param name="text">text to write</param>
        public static void Error(string text)
        {
            WriteLog(text, LogLevel.ERROR);
        }

        /// <summary>
        /// INFO logging
        /// </summary>
        /// <param name="text">text to write</param>
        public static void Info(string text)
        {
            WriteLog(text, LogLevel.INFO);
        }

        /// <summary>
        /// A method that write logs to a file
        /// </summary>
        /// <param name="text">text to write</param>
        /// <param name="level">log level</param>
        private static void WriteLog(string text, LogLevel level)
        {
            FileStream ostrm = null;
            StreamWriter writer = null;
            var oldOut = Console.Out;
            string dateAndTime = string.Empty;
            try
            {
                lock (ObectToLock)
                {
                    string path = AssemblyDirectoryPath + "//logs.txt";
                    ostrm = new FileStream(path, FileMode.Append, FileAccess.Write);
                    writer = new StreamWriter(ostrm);
                    dateAndTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff tt");
                    Console.SetOut(writer);
                    Console.WriteLine($"[{dateAndTime}] {level}: {text}");
                    Console.SetOut(oldOut);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open 'logs.txt' for writing");
                Console.WriteLine(e.Message);
            }
            finally
            {
                writer?.Close();
                ostrm?.Close();
            }
        }

        /// <summary>
        /// Gets  the assembly directory path.
        /// </summary>
        public static string AssemblyDirectoryPath
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
