using InvoiceManager_BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_BuinessService_Interface
{
    public interface IInvoiceManagerService
    {
        Task<bool> CreateInvoice(Invoicemodel model);


        Task<Invoicemodel> EditInvoice(Invoicemodel model);
    }
}
