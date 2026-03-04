using OpenQA.Selenium;
using OpenQA.Selenium;
using System;
using System.Drawing;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO;
using Tools.General_Tools;
using Tools.General_Tools.Windows;
using WebAutomation.Web.Core.Others;
using WebAutomation.Web.Core.WebBrowser;
using ZXing;




namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Image : WE_Base
    {

        public WE_Image(By locator)
        {
            SetElement(locator);
        }

        public WE_Image(IWebElement givenElement)
        {
            SetElement(givenElement);
        }

        public WE_Image(By locator, WE_Iframe homeFrame)
        {
            SetElement(locator, homeFrame);
        }

        public WE_Image(IWebElement givenElement, WE_Iframe homeFrame)
        {
            SetElement(givenElement, homeFrame);
        }

        public void Click()
        {
            WE_Interactions.Click.OnElement(element);
        }

        public void ClickAndWaitForPageToLoad(int miliseconds)
        {
            WE_Interactions.Click.AndWaitForPageToLoad(element, miliseconds);
        }

        public void Download(string name)
        {
            string source = GetAttributeValue("src");
            string fileName = FileManager_Tool.GetProjectTempPath() + Path.AltDirectorySeparatorChar + name + ".jpeg";
            WebClient_Tool.DownloadFile(source, fileName);
        }

        public Rectangle GetImageSizeAndPosition()
        {
            return new Rectangle(((Size)element.Location).Width, ((Size)element.Location).Height, ((Size)element.Location).Height, ((Size)element.Location).Width);
        }

        public Point GetLocation()
        {
            return element.Location;
        }

        public void NavigateToSource()
        {
            WB_Interactions.GoToUrl(GetAttributeValue("src"));
        }

        /// <summary>
        /// @TODO: Continue with the implementation of this method, it should take a screenshot of the image element and save it to the specified path.
        /// 
        /// It should use the coordinates of the WebElement image and take a screenshot of that area, then save it to the specified path.
        /// 
        /// </summary>
        /// <param name="nameAndPath"></param>
        public void TakeScreenshot(string nameAndPath)
        {
  
            // 1. Scroll the element into view
            JScript.ExecuteGivenJs("arguments[0].scrollIntoView(true);", element);

            // Allow some time for the scrolling to complete and the element to be fully rendered
            System.Threading.Thread.Sleep(500);

            // 2. Take a screenshot of the entire viewport
            var screenshot = ((ITakesScreenshot)SeleniumCore.driver).GetScreenshot();

            // 3. Get the location and size of the element
            Point elementLocation = element.Location;
            Size elementSize = element.Size;

            // Create a bitmap from the full screenshot
            using (var ms = new MemoryStream(screenshot.AsByteArray))
            using (var fullImage = new Bitmap(ms))
            {
                // 4. Crop the full image to the element's dimensions
                var elementRect = new Rectangle(elementLocation, elementSize);
                using (var croppedImage = fullImage.Clone(elementRect, fullImage.PixelFormat))
                {
                    // 5. Save the cropped image
                    croppedImage.Save(FileManager_Tool.GetProjectTempPath() + Path.AltDirectorySeparatorChar + nameAndPath + ".jpeg", ImageFormat.Jpeg);
                }
            }

        }
    }
}
