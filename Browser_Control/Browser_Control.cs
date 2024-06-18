using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace BUMBLEBEE
{
    internal class Brwoser_Control
    {
        internal IWebDriver webDriver;
        internal ChromeOptions chromeOptions;


        internal Brwoser_Control()
        {
            chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--log-level=3");
            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddArgument("--disable-web-security");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--disable-features=NetworkService,NetworkServiceInProcess");
            chromeOptions.AddArgument("--allow-running-insecure-content");
            chromeOptions.AddArgument("--disable-cache");
            chromeOptions.AddArgument("--disk-cache-size=0");
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddExtension(Tools.GetCurretPath("01_Extensions\\disableCookies.crx"));
            chromeOptions.AddExtension(Tools.GetCurretPath("01_Extensions\\adguard.crx"));
            webDriver = new ChromeDriver(chromeOptions);
            SwitchToFirstTabAndCloseOthers();
        }


        internal void OpenUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }


        internal IWebElement? FindWaitElement(string selectorValue)
        {
            int attempts = 0;
            var attemtTime = 1000;
            while (attempts < 7)
            {
                try
                {
                    attempts++;
                    IWebElement? element = TrySelector(selectorValue);
                    _ = ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", element);
                    Thread.Sleep(attemtTime);
                    return element;
                }
                catch
                {
                    Thread.Sleep(attemtTime);
                }
            }
            return null;
        }


        internal IWebElement? TrySelector(string selectorValue)
        {
            IWebElement? element;
            try
            {
                element = webDriver.FindElement(By.XPath($"//*[text()='{selectorValue}']"));
                // Tools.Print($"Found by XPath Text", ConsoleColor.Green);
                return element;
            }
            catch { }

            try
            {
                element = webDriver.FindElement(By.Id(selectorValue));
                // Tools.Print("Found element by ID", ConsoleColor.Green);
                return element;
            }
            catch { }

            try
            {
                element = webDriver.FindElement(By.Name(selectorValue));
                // Tools.Print("Found element by Name", ConsoleColor.Green);
                return element;
            }
            catch { }

            try
            {
                element = webDriver.FindElement(By.ClassName(selectorValue));
                // Console.WriteLine("Found element by ClassName", ConsoleColor.Green);
                return element;
            }
            catch { }

            try
            {
                element = webDriver.FindElement(By.TagName(selectorValue));
                // Tools.Print("Found element by TagName", ConsoleColor.Green);
                return element;
            }
            catch { }

            try
            {
                element = webDriver.FindElement(By.CssSelector(selectorValue));
                // Console.WriteLine("Found element by CssSelector", ConsoleColor.Green);
                return element;
            }
            catch { }

            try
            {
                element = webDriver.FindElement(By.XPath(selectorValue));
                // Tools.Print("Found element by XPath", ConsoleColor.Green);
                return element;
            }
            catch { }

            try
            {
                element = webDriver.FindElement(By.LinkText(selectorValue));
                // Console.WriteLine("Found element by LinkText", ConsoleColor.Green);
                return element;
            }
            catch { }

            try
            {
                element = webDriver.FindElement(By.PartialLinkText(selectorValue));
                // Tools.Print("Found element by PartialLinkText", ConsoleColor.Green);
                return element;
            }
            catch { }

            return null;
        }


        internal void SwitchToFirstTabAndCloseOthers()
        {
            try
            {
                Thread.Sleep(1000);
                var handles = webDriver.WindowHandles;
                string firstTabHandle = handles[0]; // Der Handle des ersten Tabs
                foreach (var handle in handles)
                {
                    if (handle != firstTabHandle) // Wenn es nicht der erste Tab ist
                    {
                        webDriver.SwitchTo().Window(handle); // Wechseln zu diesem Tab
                        webDriver.Close(); // Diesen Tab schließen
                    }
                }

                webDriver.SwitchTo().Window(firstTabHandle); // Wechseln zurück zum ersten Tab
            }
            catch (Exception ex)
            {
                Tools.Print($"[LOG]> {ex.Message}", ConsoleColor.Red);
            }
        }


    }
}
