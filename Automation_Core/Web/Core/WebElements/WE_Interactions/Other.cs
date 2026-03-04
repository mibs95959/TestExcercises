using OpenQA.Selenium;
using SkiaSharp;
using System.IO;

namespace WebAutomation.Web.Core.WebElements.WE_Interactions
{
    public class Other : SeleniumCore
    {


        public static string GetElementHyperlink(By _locator)
        {
            return Find.Element(_locator).GetAttribute("href");
        }

        public static string GetElementHyperlink(IWebElement element)
        {
            return element.GetAttribute("href");
        }

        public static string GetElementGivenAttribute(By _locator, string attribute)
        {
            return Find.Element(_locator).GetAttribute(attribute);
        }

        public static string GetElementGivenAttribute(IWebElement element, string attribute)
        {
            return element.GetAttribute(attribute);
        }



        // Screenshot:

        public static SKBitmap GetElementScreenShot(IWebElement element, string nameAndPath)
        {
            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            var img = SKBitmap.Decode(sc.AsByteArray);
            var rect = new SKRectI(element.Location.X, element.Location.Y, element.Location.X + element.Size.Width, element.Location.Y + element.Size.Height);

            using var pixmap = new SKPixmap(img.Info, img.GetPixels());
            using var subset = pixmap.ExtractSubset(rect);

            var cropped = new SKBitmap(subset.Info);
            cropped.InstallPixels(subset.Info, subset.GetPixels());

            using var data = subset.Encode(SKPngEncoderOptions.Default);

            File.WriteAllBytes(nameAndPath, data.ToArray());
            return cropped;
        }


    }
}
