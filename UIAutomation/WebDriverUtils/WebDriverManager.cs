namespace UIAutomation.WebDriverUtils
{
    using UIAutomation.Utilities.Logger;
    public class WebDriverManager : DriverManager
    {
        private static WebDriverManager instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverManager"/> class.
        /// Constructor of WebDriverManager
        /// </summary>
        private WebDriverManager()
        {
            this.InitWebDriver();
        }

        /// <summary>
        /// Method to initialize Web Driver
        /// </summary>
        public new void InitWebDriver()
        {
            Logging.Debug($"Initializing WebDriver");
            base.InitWebDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        /// <summary>
        /// Make Webdriver Manager Instance as null;
        /// </summary>
        public static void DisposeWebDriverManager() => instance = null;


        public static WebDriverManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebDriverManager();
                }

                return instance;
            }
        }

    }
}
