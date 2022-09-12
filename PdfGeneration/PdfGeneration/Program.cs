

using PdfGeneration;
using PdfGeneration.Model;

Invoice model = InvoiceDataSource.GetInvoiceDetails();
InvoiceBuilder invoiceBuilder = new InvoiceBuilder(model);
invoiceBuilder.GeneratePDF();