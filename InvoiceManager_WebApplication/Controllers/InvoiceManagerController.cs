using InvoiceManager_BuinessService_Interface; 
using InvoiceManager_BusinessEntity;
using InvoiceManager_BusinessService;
using InvoiceManager_DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManager_WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceManagerController :  ControllerBase
    {

         private readonly IInvoiceManagerService _InvoiceManagerService;
       
        public InvoiceManagerController()
        {
                _InvoiceManagerService = new InoviceManagerService();
        }

        //GET api/<ValuesController>/5
        [HttpPost("save")]
        public async Task<IActionResult> Create(Invoicemodel invoice)
        {
            bool status = await _InvoiceManagerService.CreateInvoice(invoice);
            return Ok();
        }

        [HttpPost("edit")]
        public async Task<IActionResult>  update(Invoicemodel invoice)
        {
            Invoicemodel result = await _InvoiceManagerService.EditInvoice(invoice);
            return Ok(result);
        }
    }
}
