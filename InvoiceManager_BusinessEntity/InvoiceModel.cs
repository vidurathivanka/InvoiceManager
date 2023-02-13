namespace InvoiceManager_BusinessEntity
{
    public class Invoicemodel
    {
        public string Id { get; set; }
        public int InoviceNumber { get; set; }

        public string Description { get; set; }

        public decimal TotalAmount { get; set; }

        public List<LineItemModel> lineItems { get; set; }
        public DateTime date { get; set; }

        public int Status { get; set; }



        public Invoicemodel()
        {
            Description = "";
            lineItems = new List<LineItemModel>();
        }

    }
    public class LineItemModel
    {
        public int LineNumber { get; set; }

        public string ItemName { get; set; }

        public double quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public  int Status { get; set; }
    }
}