using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfGeneration.Model
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public string IssueDate { get; set; }
        public string DueDate { get; set; }

        public UserDetails CompanyDetails { get; set; }
        public UserDetails CustomerDetails { get; set; }

        public List<Item> Items { get; set; }

        public decimal SubTotal
        {
            get
            {
                return Items.Sum(x => x.Price * x.Quantity);
            }
        }

        public float Tax
        {
            get
            {
                return (float)SubTotal * (25f / 100f);
            }
        }

        public float GrandTotal
        {
            get
            {
                return (float)SubTotal + Tax;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Quantity * Price;
            }
        }
    }

    public class UserDetails
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
