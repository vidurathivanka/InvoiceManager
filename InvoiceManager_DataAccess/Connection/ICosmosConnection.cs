using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_DataAccess.Connection
{
    public interface ICosmosConnection
    { 
            Task<DocumentClient> InitializeAsync(string collectionId);
         
    }
}
