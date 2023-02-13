using InvoiceManager_BuinessProccess;
using InvoiceManager_BuinessService_Interface;
using InvoiceManager_BusinessEntity;

namespace InvoiceManager_BusinessService
{  
    public class InoviceManagerService : IInvoiceManagerService
    {
        private Invoice_BusinessProccessor inovice_BusinessProccessor { get; set; }
        public Task<bool> CreateInvoice(Invoicemodel model)
        {
            inovice_BusinessProccessor = new Invoice_BusinessProccessor();
            return inovice_BusinessProccessor.CreateInvoice(model); 
        }

        public  Task<Invoicemodel>   EditInvoice(Invoicemodel model)
        {
            inovice_BusinessProccessor = new Invoice_BusinessProccessor();
            return inovice_BusinessProccessor.EditInvoice(model);
        }
    }
}