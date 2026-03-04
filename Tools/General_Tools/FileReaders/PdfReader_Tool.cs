using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using pdftron.PDF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.General_Tools.FileReaders
{
    public class PdfReader_Tool
    {

        private static PDFViewCtrl view = new PDFViewCtrl();

        public static bool PdfContains(string path, string text)
        {
            PDFDoc doc = new PDFDoc(path);
            Page page = doc.GetPage(1);

            TextExtractor txt = new TextExtractor();
            
            txt.Begin(page);
            txt.GetAsText();

            return page.GetContents().ToString().Contains(text);
        }

        private static int PageCount(string path)
        {
            var pdf = File.ReadAllBytes(@path);
            using (var stream = new MemoryStream(pdf))
            {
                using (var reader = new PdfReader(stream))
                {
                    using (var document = new PdfDocument(reader))
                    {
                        return document.GetNumberOfPages();
                    }
                }
            }
        }

        public static bool PdfContains_NEW(string path, string text)
        {
            using (PdfReader reader = new PdfReader(path))
            {
                PdfDocument doc = new PdfDocument(reader);
                for (int pageNumber = 1; pageNumber <= PageCount(path); pageNumber++)
                {
                    string currentText = PdfTextExtractor.GetTextFromPage(doc.GetPage(pageNumber));
                    if (Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText))).Contains(text)) return true;
                }
                reader.Close();
            }
            return false;
        }

        public static string GetLineThatContains(string path, string input)
        {

            using (PdfReader reader = new PdfReader(path))
            {
                PdfDocument doc = new PdfDocument(reader);
                for (int pageNumber = 1; pageNumber <= PageCount(path); pageNumber++)
                {
                    string currentText = PdfTextExtractor.GetTextFromPage(doc.GetPage(pageNumber));
                    string currentLine = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    if (currentLine.Contains(input)) return currentLine;
                }
                reader.Close();
            }
            return null;


        }
        
    }
}
