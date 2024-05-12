namespace UIAutomation.Enironments
{
    using Newtonsoft.Json;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using UIAutomation.Utilities.Logger;
    public class EnvironmentManager
    {


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

        /// <summary>
        /// Method that gets the rout from where it's running
        /// </summary>
        /// <returns>string path</returns>
        public static string GetPath()
        {
            try
            {
                Logging.Debug("Get Path for running file..");
                string commonPath = $"{ConfigurationManager.AppSettings["Environment"]}.json";
                var fullPath = AssemblyDirectoryPath + "\\" + commonPath;
                Logging.Debug($"Path is '{fullPath}'");
                return fullPath;
            }
            catch (Exception exception)
            {
                Logging.Error($"Something went wrong on getting a path.\n{exception.Message}");
                return string.Empty;
            }
        }
        /// <summary>
        /// Method that gets the URL from Environment file
        /// </summary>
        /// <returns>string URL</returns>
        public static String GetURL()
        {
            string stringJson = System.IO.File.ReadAllText(GetPath());
            return JsonConvert.DeserializeObject<URL>(stringJson).url;
        }
    }
}
