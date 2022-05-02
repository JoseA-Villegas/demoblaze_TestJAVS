using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;

namespace demoBlazeAutomation_JAVS.Handler
{
    public class ScreenShotHandler
    {

        private static string ImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string TakeScreenShot(IWebDriver driver)
        {
            long miliseconds = DateTime.Now.Ticks/ TimeSpan.TicksPerMillisecond;

            string imagePath = ImagePath + "//img_" + miliseconds + ".png";
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(imagePath, ScreenshotImageFormat.Png);

            return imagePath;
        }
    }
}
