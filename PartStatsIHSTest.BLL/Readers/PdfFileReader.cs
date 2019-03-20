using System.Collections.Generic;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PartStatsIHSTest.BLL.Interfacies;

namespace PartStatsIHSTest.BLL.Readers
{
    public class PdfFileReader : IFileReader
    {
        public string[] ReadFromFile(string fullName, Encoding encoding)
        {
            List<string> linesResult = new List<string>();

            using (PdfReader reader = new PdfReader(fullName))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string thePage = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                    string[] theLines = thePage.Split('\n');
                    linesResult.AddRange(theLines);
                }
            }

            return linesResult?.ToArray();
        }

       
    }
}
