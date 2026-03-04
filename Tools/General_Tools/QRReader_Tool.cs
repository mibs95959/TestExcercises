using SkiaSharp;
using System.Collections.Generic;
using ZXing;
using ZXing.Common;
using static ZXing.RGBLuminanceSource;

namespace Tools.General_Tools
{
    public class QRReader_Tool
    {

        public static string QRImageDecoder(string imagePath)
        {

            SKBitmap bitmap = SKBitmap.Decode(imagePath);

            var options = new DecodingOptions
            {
                PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE },
                TryHarder = true,
                TryInverted = false
            };

            using (bitmap)
            {
                var reader = new BarcodeReader<SKBitmap>(null, null, ls => new GlobalHistogramBinarizer(ls)) { AutoRotate = false, Options = options };
                var result = reader.Decode(bitmap.Bytes, bitmap.Width, bitmap.Height, BitmapFormat.Unknown);
                reader = null;

                return result.Text;
            }
        }

        public static string QRImageDecoder(SKBitmap input)
        {
            var options = new DecodingOptions
            {
                PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE },
                TryHarder = true,
                TryInverted = false
            };

            using (input)
            {
                var reader = new BarcodeReader<SKBitmap>(null, null, ls => new GlobalHistogramBinarizer(ls)) { AutoRotate = false, Options = options };
                var result = reader.Decode(input.Bytes, input.Width, input.Height, BitmapFormat.Unknown);
                reader = null;
                return result.Text;
            }
        }

    }
}
