using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;

internal class PDFFileReader : IFileReader
{
    public IEnumerable<string> Read(string path)
    {
        foreach (var filePath in Directory.GetFiles(path, "*.pdf"))
        {
            using PdfDocument document = PdfDocument.Open(filePath);
            int pageCount = document.NumberOfPages;

            // Page number starts from 1, not 0.
            Page page = document.GetPage(1);

            yield return page.Text;
        }
    }
}