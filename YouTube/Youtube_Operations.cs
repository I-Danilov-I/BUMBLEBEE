/*
using OpenQA.Selenium;

using OpenQA.Selenium.Interactions;

namespace BUBLEBEE
{
    public static class YouTubeOperations
    {
        public static bool YoutubeLive(IWebDriver driver, List<string> commitMessages, int howManyCommits)
        {
            driver.Navigate().GoToUrl(Program.targetLink);
            return true;
        }



    
        public static bool YoutubeShoots(IWebDriver driver, List<string> commitMessages, int howManyCommits)
        { 
            try
            {
                driver.Navigate().GoToUrl(Program.targetLink);

                // Tools.RandomSleep(3, 7);
                IWebElement? mute = Tools.Wait(driver, By.ClassName("YtdDesktopShortsVolumeControlsMuteIconButton"), "Mute");
                if (string.Equals(Program.sound, "OFF", StringComparison.OrdinalIgnoreCase))
                {
                    mute?.Click();
                }


                // Tools.RandomSleep(10, 60);
                if (string.Equals(Program.likeORDiss, "LIKE", StringComparison.OrdinalIgnoreCase))
                {
                    // Find and click the like button // ID: like-button
                    IWebElement? like = Tools.Wait(driver, By.XPath("//*[@id=\"like-button\"]/yt-button-shape/label/button/yt-touch-feedback-shape/div/div[2]"), "Like");
                    like?.Click();
                }
                else if (string.Equals(Program.likeORDiss, "DISS", StringComparison.OrdinalIgnoreCase))
                {
                    // Find and click the dislike button // ID: dislike-button
                    IWebElement? disLike = Tools.Wait(driver, By.XPath("//*[@id=\"dislike-button\"]/yt-button-shape/label/button"), "Diss Like");
                    disLike?.Click();
                }


                // Tools.RandomSleep(10, 30);
                if (string.Equals(Program.subcribeFuntion, "ON", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.Equals(Program.subcribeMenu, "SUBSCRIBE", StringComparison.OrdinalIgnoreCase))
                    {
                        // Css Selector: "button[aria-label*="Abo"]"
                        IWebElement? subscribeCheck = Tools.Wait(driver, By.XPath("//*[@id=\"subscribe-button-shape\"]/button"), "Subcribe Check");
                        // Console.WriteLine(subscribeCheck?.Text);
                        if (subscribeCheck?.Text == "Subscribe")
                        {
                            // Console.WriteLine("Noch kein Abo");
                            IWebElement? subscribe = Tools.Wait(driver, By.XPath("//*[@id=\"subscribe-button-shape\"]/button/yt-touch-feedback-shape/div/div[2]"), "Subcribe");
                            subscribe?.Click();
                            subscribe = null;
                            
                        }
                        else
                        {
                            // Console.WriteLine("Bereit Aboniert");
                        }
                        subscribeCheck = null;
                    }


                    if (string.Equals(Program.subcribeMenu, "UNSUBSCRIBE", StringComparison.OrdinalIgnoreCase))
                    {
                        // Css Selector: "button[aria-label*="Abo"]"
                        IWebElement? subscribeCheck = Tools.Wait(driver, By.XPath("//*[@id=\"subscribe-button-shape\"]/button"), "Subcribe Check");
                        Console.WriteLine(subscribeCheck?.Text);
                        if (subscribeCheck?.Text == "Subscribe")
                        {
                            // Console.WriteLine("Kein Abo");
                        }
                        else
                        {
                            // Console.WriteLine("Aktuell Aboniert");
                            IWebElement? unsubscribe = Tools.Wait(driver, By.Id("subscribe-button-shape"), "Un-Subcribe");
                            unsubscribe?.Click();

                            Actions actions = new Actions(driver);                 
                            actions.SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();

                            unsubscribe = null;
                        }
                    }
                }


                // Tools.RandomSleep(10, 60);
                if (Program.commitsProUser != 0)
                {
                    Random random = new Random();
                    int commitCounter = 0;

                    while (commitCounter < howManyCommits)
                    {
                        commitCounter++;
                       
                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver; // Scrollen Sie ein Stück nach unten
                        js.ExecuteScript("window.scrollBy(0,250)"); // Ändern Sie 250 auf die gewünschte Anzahl von Pixeln

                        IWebElement? commentEdit = Tools.Wait(driver, By.Id("comments-button"), "Komment öffnen");
                        commentEdit?.Click();
                        commentEdit = null;

                        IWebElement? commentFreigeben = Tools.Wait(driver, By.Id("simplebox-placeholder"), "Komment freigeben");
                        commentFreigeben?.Click();
                        commentFreigeben = null;

                        IWebElement? commentInput = Tools.Wait(driver, By.CssSelector("#contenteditable-root"), "Komment Setzen");
                        string randomCommit = commitMessages[random.Next(commitMessages.Count)];
                        commentInput?.SendKeys(randomCommit);
                        commentInput = null;

                        IWebElement? commentSend = Tools.Wait(driver, By.Id("submit-button"), "Absenden");
                        commentSend?.Click();
                        commentSend = null;

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Tools.Print($"\n\n[LOG]> {ex.Message}", ConsoleColor.Red);
                return false;
            }
        }





        public static bool YoutubeDefalt(IWebDriver driver, List<string> commitMessages, int howManyCommits)
        {
            try
            {
                driver.Navigate().GoToUrl(Program.targetLink);
                Program.succesInProzent++;

                Tools.RandomSleep(3, 7);
                IWebElement? mute = Tools.Wait(driver, By.CssSelector("button.ytp-mute-button"), "Mute");
                if (string.Equals(Program.sound, "OFF", StringComparison.OrdinalIgnoreCase))
                {
                    mute?.Click();
                }
                Program.succesInProzent++;


                Tools.RandomSleep(10, 60);
                if (string.Equals(Program.likeORDiss, "LIKE", StringComparison.OrdinalIgnoreCase))
                {
                    // Find and click the like button
                    IWebElement? like = Tools.Wait(driver, By.XPath("//*[@id=\"top-level-buttons-computed\"]/segmented-like-dislike-button-view-model/yt-smartimation/div/div/like-button-view-model/toggle-button-view-model/button-view-model/button"), "Like");
                    like?.Click();
                }
                else if (string.Equals(Program.likeORDiss, "DISS", StringComparison.OrdinalIgnoreCase))
                {
                    // Find and click the dislike button
                    IWebElement? disLike = Tools.Wait(driver, By.XPath("//*[@id=\"top-level-buttons-computed\"]/segmented-like-dislike-button-view-model/yt-smartimation/div/div/dislike-button-view-model/toggle-button-view-model/button-view-model/button/yt-touch-feedback-shape/div"), "Diss Like");
                    disLike?.Click();
                }

                Tools.RandomSleep(10, 30);
                if (string.Equals(Program.subcribeFuntion, "ON", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        IWebElement? subscribe = Tools.Wait(driver, By.XPath("//*[@id=\"subscribe-button-shape\"]/button"), "Subcribe");
                        subscribe?.Click();
                        subscribe = null;
                        Program.succesInProzent++;

                    }
                    catch { }

 
                    IWebElement? unsubcribe = Tools.Wait(driver, By.XPath("//*[@id=\"notification-preference-button\"]/ytd-subscription-notification-toggle-button-renderer-next/yt-button-shape/button/yt-touch-feedback-shape/div"), "Open Dopmenü Unsubcribe");
                    unsubcribe?.Click();

                    var menuItems = driver.FindElements(By.CssSelector("tp-yt-paper-listbox#items ytd-menu-service-item-renderer tp-yt-paper-item"));

                    foreach (var item in menuItems)
                    {

                        if (string.Equals(item.Text, Program.subcribeMenu, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Click();
                            if (string.Equals(Program.subcribeMenu, "UNSUBSCRIBE", StringComparison.OrdinalIgnoreCase))
                            {
                                IWebElement? sureunsubscribe = Tools.Wait(driver, By.XPath("//*[@id=\"confirm-button\"]/yt-button-shape/button/yt-touch-feedback-shape/div"), "Bestatige Unsubbcribe");
                                sureunsubscribe?.Click();
                            }
                        }
                    }
                }


                Tools.RandomSleep(10, 60);
                if (string.Equals(Program.commitsProUser != 0, StringComparison.OrdinalIgnoreCase))
                {
                    Random random = new Random();
                    int commitCounter = 0;
                    Program.succesInProzent++;
                    while (commitCounter < howManyCommits)
                    {
                        commitCounter++;

                        IWebElement? commentEdit = Tools.Wait(driver, By.XPath("//*[@id=\"placeholder-area\"]"), "Komment freigeben");
                        commentEdit?.Click();
                        commentEdit = null;

                        IWebElement? commentInput = Tools.Wait(driver, By.CssSelector("#contenteditable-root"), "Komment Setzen");
                        string randomCommit = commitMessages[random.Next(commitMessages.Count)];
                        commentInput?.SendKeys(randomCommit);
                        commentInput = null;

                        IWebElement? commentSend = Tools.Wait(driver, By.XPath("//*[@id=\"submit-button\"]/yt-button-shape/button/yt-touch-feedback-shape/div/div[2]"), "Comment Send");
                        commentSend?.Click();
                        commentInput = null;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Tools.Print($"[LOG]> {ex.Message}", ConsoleColor.Red);
                return false;
            }
        }
    }
}
*/