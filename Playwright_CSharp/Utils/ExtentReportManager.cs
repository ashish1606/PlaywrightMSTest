using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Utils
{
    public static class ExtentReportManager
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {

                string fileName = DateTime.Now.ToString().Replace(":", "_").Replace(" ", "_").Replace("/", "_") + ".html";
            
                string projectDirectoryPath = Directory.GetCurrentDirectory();
                string parentDirectoryPath = Path.GetFullPath(Path.Combine(projectDirectoryPath, ".."));
                string parentToParentDirectoryPath = Path.GetFullPath(Path.Combine(parentDirectoryPath, ".."));
                string superParentDirectoryPath = Path.GetFullPath(Path.Combine(parentToParentDirectoryPath, ".."));
             
                string reportName = "Reports";
                string fullPath = Path.Combine(superParentDirectoryPath, reportName, fileName);

                htmlReporter = new ExtentHtmlReporter(fullPath);
                htmlReporter.Configuration().DocumentTitle = "Playwright Test Reporter";
                htmlReporter.Configuration().ReportName = "Playwright Auotmation Report";
                htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }

      

        public static void Flush()
        {
            extent.Flush();

        }

    }
}
