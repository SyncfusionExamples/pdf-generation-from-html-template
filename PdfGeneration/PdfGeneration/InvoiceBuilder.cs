
using PdfGeneration.Model;
using Scriban;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace PdfGeneration
{
    public class InvoiceBuilder
    {
        Invoice invoice;

        public InvoiceBuilder(Invoice model)
        {
            this.invoice = model;
        }

        public void GeneratePDF()
        {   
            //Load html template
            var invoiceTemplate = File.ReadAllText("../../../Template/index.html");
            var template = Template.Parse(invoiceTemplate);
            var templateData = new { invoice };
            //Fill template with real invoice data
            var pageContent = template.Render(templateData);
            //Convert html to PDF
            ConvertToPDF(pageContent);
        }

        private void ConvertToPDF(string pageContent)
        {
            
            //Initialize HTML to PDF converter with Blink rendering engine
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);

            //Convert HTML string to PDF
            PdfDocument document = htmlConverter.Convert(pageContent, Path.GetFullPath("Template"));

            FileStream fs = new FileStream("Output.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //Save and close the PDF document 
            document.Save(fs);

            document.Close(true);
        }
    }
}
