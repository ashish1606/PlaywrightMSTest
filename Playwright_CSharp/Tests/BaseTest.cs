//using Allure.Commons;
using Allure.Net.Commons;
using AventStack.ExtentReports;
using Microsoft.Playwright;
using Playwright_CSharp.Config;
using Playwright_CSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Tests
{
    [TestClass]
    public class BaseTest
    {

        protected IBrowser browser;
        protected IBrowserContext context;
        protected IPage page;
        protected static ExtentReports extentReports;
        protected ExtentTest extentTest;
        protected static string reportDirectory;
        private static string directoryPath;

        private string testName;
        private static string screenshotsDirectory;
        private static string videoDirectory;
        private static string tracesDirectory;
        private static string timeStamp;
        public TestContext TestContext { get; set; }
        private static AllureLifecycle Allure = AllureLifecycle.Instance;

        //protected static IAPIRequestContext APIRequestContext;
        //protected static IAPIRequest APIRequest;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            ConfigReader.PopulateSettings();
            timeStamp = DateTime.Now.ToString().Replace(":", "_").Replace(" ", "_").Replace("/", "_");
            
            //Create Directory If It does not Exist

            screenshotsDirectory = CreateDirectoryIfDoesNotExist("Screenshots");
            tracesDirectory = CreateDirectoryIfDoesNotExist("Traces");
            videoDirectory = CreateDirectoryIfDoesNotExist("Videos");
            reportDirectory = CreateDirectoryIfDoesNotExist("Reports");


            extentReports = ExtentReportManager.GetExtent();
            
        }

        [TestInitialize]
        public async Task TestInitialize()
        {
            testName = TestContext.TestName;
            extentTest = extentReports.CreateTest(testName);
            //AllureLifecycle allureLifecycle = Allure.StartTestCase();
            //Allure.StartTestContainer("PlaywrightTestsContainer");

            var browserType = Settings.BrowserName;
            IBrowserType launchBroswerType = browserType
            switch
            {
                "firefox" => Playwright.CreateAsync().Result.Firefox,
                "webkit" => Playwright.CreateAsync().Result.Webkit,
                _ => Playwright.CreateAsync().Result.Chromium,
            };

            //Determine Headless mode

            bool headless = Settings.Headless;

            // Launch Browser with specified option

            browser = await launchBroswerType.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = headless });

            //var browserContext = await FrameworkConfig.browser.NewContextAsync();

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {

                RecordVideoDir = videoDirectory,
                RecordVideoSize = new RecordVideoSize { Width = 1280, Height = 720 }



            });

            await context.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true


            });


            //extentTest.Log(Status.Info, "Navigating to the application page");
            page = await context.NewPageAsync();

            await page.GotoAsync(Settings.TestURL);


            

        }

        [TestCleanup]
        public async Task TearDown()
        {
            //Capture Screenshots if text cases are failed

            if (TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
  
            {
                string scrrenShotsPath = Path.Combine(screenshotsDirectory, testName, $"{timeStamp}.png");
                await page.ScreenshotAsync(new PageScreenshotOptions { Path = scrrenShotsPath });

                //Add screenshot to the allure report
                //AllureLifecycle.AddAttachment(testName,"",scrrenShotsPath);


            }

            //stop tracing and save trace
            await context.Tracing.StopAsync(new TracingStopOptions { Path = Path.Combine(tracesDirectory, testName, $"{timeStamp}.zip") });

            //Add Videos attachment to the allure report
            //Allure.StopTestCase();
           

            await context.CloseAsync();
            await browser.CloseAsync();

            


        }

        [AssemblyCleanup]
        public static void  AssemblyCleanup()
        {

           // ExtentReportManager.Flush();

        }


        private static string CreateDirectoryIfDoesNotExist(string directoryName)
        {

            string projectDirectoryPath = Directory.GetCurrentDirectory();
            string parentDirectoryPath = Path.GetFullPath(Path.Combine(projectDirectoryPath, ".."));
            string parentToParentDirectoryPath = Path.GetFullPath(Path.Combine(parentDirectoryPath, ".."));
            string superParentDirectoryPath = Path.GetFullPath(Path.Combine(parentToParentDirectoryPath, ".."));
            try
            {
                directoryPath = superParentDirectoryPath + "\\" + directoryName;
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                Console.WriteLine("Directory Created at : " + directoryPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured : {ex.Message}");
            }
            return directoryPath;
        }


    }

}
