using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfGeneration.Model
{
    public static class InvoiceDataSource
    {
        public static Invoice GetInvoiceDetails()
        {
            Invoice invoice = JsonConvert.DeserializeObject<Invoice>(File.ReadAllText("../../../InvoiceData.json"));
            return invoice;
        }
    }
}
