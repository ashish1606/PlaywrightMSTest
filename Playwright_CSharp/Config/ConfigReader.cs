using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Config
{
    public class ConfigReader
    {

        public void ReadProperty()
        {

            string filePath = "C:\\Ashish\\Project\\ExpleoPlaywrightFramework\\ExpleoPlaywrightFramework\\Config\\config.properties";
            Dictionary<string, string> properties = LoadProperties(filePath);

            // Accessing Properties

            Settings.BrowserName = properties["BrowserName"];
            Settings.Headless = bool.Parse(properties["Headless"]);
            // Settings.DeviceEmulationType = properties["DeviceEmulationType"];
            Settings.TestURL = properties["TEST_URL"];
            

            static Dictionary<string, string> LoadProperties(string filePath)
            {
                var properties = new Dictionary<string, string>();
                foreach (var line in File.ReadAllLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        properties[key] = value;
                    }
                }
                return properties;
            }

        }
        public static void PopulateSettings()
        {
            ConfigReader reader = new ConfigReader();
            try
            {
                reader.ReadProperty();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }




    }
}
