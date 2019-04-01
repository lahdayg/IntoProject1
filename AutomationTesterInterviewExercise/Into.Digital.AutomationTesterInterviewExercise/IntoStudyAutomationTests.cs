using System;
using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace Into.Digital.AutomationTesterInterviewExercise
{
    /// <summary>
    ///     This is the entry point for automation tests for the INTO Study platform.
    /// </summary>
    public class IntoStudyAutomationTests : DriverArrange
    {
        /// <summary>
        ///     Injected to provide an instance of the <see cref="ITestOutputHelper"/>
        /// </summary>
        /// <remarks>The <see cref="ITestOutputHelper"/> is preferred over <see cref="Console"/> writes.</remarks>
        private readonly ITestOutputHelper _theOutputHelper;

        /// <summary>
        ///     Constructor, into which we inject any dependencies.
        /// </summary>
        /// <param name="outputHelper"></param>
        public IntoStudyAutomationTests(ITestOutputHelper theOutputHelper)
        {
            _theOutputHelper = theOutputHelper;
        }

        /// <summary>
        ///     This tests the University pages in the following steps:
        ///         * Loads INTO Study homepage.
        ///         * Navigates to the Universities page.
        ///         * Clicks "View More" CTA on the university card. 
        /// </summary>
        [Fact]
        public void ClickingTheViewMoreButtonLoadsAUniversityPage()
        {
            // Opens browser and navigates to the INTO Study homepage.
            if (OpenBrowser())
            {
                _theOutputHelper.WriteLine("Opening browser.");

                // Wait.
                Wait(2000);

                // Navigates to Universities page.
                driver.FindElement(By.LinkText("Universities")).Click();

                _theOutputHelper.WriteLine("Navigating to the Universities page.");

                // Wait.
                Wait(2000);

                // Selects "View More" on the university card.
                driver.FindElements(By.CssSelector(".l-cta.cta"))[0].Click();

                _theOutputHelper.WriteLine("Clicking 'View More' on the University card.");

                // Wait.
                Wait(2000);

                // Closes the browser.
                driver.Quit();

                _theOutputHelper.WriteLine("Test Complete.");
            }
        }

        /// <summary>
        ///     This tests the changes the langauge from English to Chinese in the following steps:
        ///         * Loads INTO Study homepage.
        ///         * Change language to Chinese and zh-cn URL is displayed.
        /// </summary>
        [Fact]
        public void ChangingLanguageWillUpdateQueryParameter()
        {
            if(OpenBrowser())
            {
                // Test language switch.
            }
        }
    }
}
