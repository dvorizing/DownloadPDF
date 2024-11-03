using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Font;
using System.IO;
using iText.Kernel.Font;

namespace WebApplication100.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        [HttpGet("export")]
        public IActionResult ExportPdf()
        {
            using (var stream = new MemoryStream())
            {
                // הכנת כותב ה-PDF
                using (PdfWriter writer = new PdfWriter(stream))
                {
                    // יצירת מסמך PDF
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);

                        // נתיב לקובץ הפונט
                        string fontPath = "C:/Users/USER/Downloads/static/NotoSansHebrew-Regular.ttf";

                        // בדוק אם קובץ הפונט קיים
                        if (!System.IO.File.Exists(fontPath))
                        {
                            return BadRequest("Font file not found.");
                        }

                        // טען את הפונט
                        PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);

                        // הוסף טקסט עם הפונט
                        Paragraph paragraph = new Paragraph("שלום עולם")
                            .SetFont(font)
                            .SetFontSize(12);

                        document.Add(paragraph);

                        // סגור את המסמך
                        document.Close();
                    }
                }

                // שמור את התוכן של הזרם למערך בתים
                var fileBytes = stream.ToArray();
                return File(fileBytes, "application/pdf", "HelloWorld.pdf");
            }
        }
    }
}
