using InvoiceManager_BusinessEntity;
using InvoiceManager_DataAccess;

namespace InvoiceManager_BuinessProccess
{
    public class Invoice_BusinessProccessor
    {
        IInvoiceDataAccess _adapter;

        public Invoice_BusinessProccessor()
        {
            //_adapter = new InvoiceDataAccess();
        }
        public Task<bool> CreateInvoice(Invoicemodel model)
        { 
            var result = _adapter.CreateDocument(model);
           return result ; 
        }

        public Task<Invoicemodel> EditInvoice(Invoicemodel model)
        {
            var result =   _adapter.UpdateinvoiceAsync(model);
          return result; 
        }
    }
}