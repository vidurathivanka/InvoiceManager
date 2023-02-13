using InvoiceManager_BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_DataAccess
{
    public interface IInvoiceDataAccess
    {

        Task<bool> CreateDatabase(string name);
        Task<bool> CreateCollection(string dbName, string name);
        Task<bool> CreateDocument(Invoicemodel invoice);

        Task<Invoicemodel> UpdateinvoiceAsync(Invoicemodel invoice);

        Task<dynamic> GetData(string dbName, string name);
    }
}
