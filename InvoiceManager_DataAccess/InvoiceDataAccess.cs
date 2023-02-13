using InvoiceManager_BusinessEntity;
using InvoiceManager_DataAccess.Connection;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_DataAccess
{
    public class InvoiceDataAccess : IInvoiceDataAccess
    {
        private readonly DocumentClient _client;
        private readonly string _accountUrl;
        private readonly string _primarykey;

        public InvoiceDataAccess(
         ICosmosConnection connection,
         IConfiguration config)
        {

            _accountUrl = config.GetValue<string>("Cosmos:AccountURL");
            _primarykey = config.GetValue<string>("Cosmos:AuthKey");
            _client = new DocumentClient(new Uri(_accountUrl), _primarykey);
        }


        public async Task<bool> CreateDatabase(string name)
        {
            try
            {
                await _client.CreateDatabaseIfNotExistsAsync(new Database { Id = name });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateCollection(string dbName, string name)
        {
            try
            {
                await _client.CreateDocumentCollectionIfNotExistsAsync
                 (UriFactory.CreateDatabaseUri(dbName), new DocumentCollection { Id = name });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateDocument(Invoicemodel invoice)
        {
            string dbName = "Vidura_Test";
            string name = "Invoice";
            try
            {
                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), invoice);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<dynamic> GetData(string dbName, string name)
        {
            try
            {

                var result = await _client.ReadDocumentFeedAsync(UriFactory.CreateDocumentCollectionUri(dbName, name),
                    new FeedOptions { MaxItemCount = 10 });

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Invoicemodel> UpdateinvoiceAsync(Invoicemodel invoice)
        {
            string dbName = "Vidura_Test";
            string name = "Invoice";
            ResourceResponse<Document> response = null;
            try
            {

                var collectionUri = UriFactory.CreateDocumentUri(dbName, name, invoice.Id);
                response =  await _client.UpsertDocumentAsync(collectionUri, invoice);
            }
            catch (DocumentClientException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }

            return (dynamic)response.Resource;
        }

    }
}
