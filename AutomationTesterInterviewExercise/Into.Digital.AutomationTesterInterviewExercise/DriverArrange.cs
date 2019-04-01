using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Into.Digital.AutomationTesterInterviewExercise
{
    /// <summary>
    ///     Initializes the Selenium driver, can be inhertied from <see cref="DriverArrange"/>.
    /// </summary>
    public class DriverArrange
    {
        /// <summary>
        ///     Provides an instance of the <see cref="IWebDriver"/>.
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        ///     Constructor, into which we inject any dependencies.
        /// </summary>
        public DriverArrange()
        {
            var startupAssembly = typeof(DriverArrange).GetTypeInfo().Assembly;
            var root = GetProjectPath("", startupAssembly);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() { "start-maximized" });
            driver = new ChromeDriver(root, chromeOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    
        /// <summary>
        ///     Retrieves project path and directory info for driver setup.
        /// </summary>
        /// <param name="projectRelativePath"></param>
        /// <param name="startupAssembly"></param>
        /// <returns></returns>
        private static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
        {
            var projectName = startupAssembly.GetName().Name;
            var applicationBasePath = AppContext.BaseDirectory;
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            do
            {
                directoryInfo = directoryInfo.Parent;

                var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));
                if (projectDirectoryInfo.Exists)
                {
                    var projectFileInfo = new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj"));
                    if (projectFileInfo.Exists)
                    {
                        return Path.Combine(projectDirectoryInfo.FullName, projectName);
                    }
                }
            }
            while (directoryInfo.Parent != null);

            throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        }

        /// <summary>
        ///     Helper function for async operations.
        /// </summary>
        /// <param name="waitTime">The duration of time, in milliseconds, that the thread should sleep for.</param>
        public void Wait(int waitTime)
        {
            System.Threading.Thread.Sleep(waitTime);
        }

        /// <summary>
        ///     Removed, not being used.
        /// </summary>
        // public void ScrollDown(int keyDown)
        // { 
               // Page load and scroll down
        //     for (int i = 0; i < keyDown; i++)
        //     {
        //         driver.SwitchTo().ActiveElement().SendKeys(Keys.Down);
        //        Wait(50);
        //    }

        //    Wait(4000);
        // }

        public bool OpenBrowser()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.intostudy.com/en-gb");
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            } 
        }
    }
}
