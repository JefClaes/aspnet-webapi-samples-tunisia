using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace WebApi.EuricomCruise.Samples.Server.Controllers
{
    public class BankController : ApiController
    {
        private readonly BankStore _bankStore;

        public BankController(BankStore bankStore)
        {
            _bankStore = bankStore;
        }
       
        public IEnumerable<Bank> GetBanks()
        {
            return _bankStore.GetAll();
        }

        public Bank GetByIdentifier(string id)
        {          
            var bank = _bankStore.GetById(id);

            if (bank == null)
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.NotFound));

            return bank;                
        }

        public HttpResponseMessage PostBank(Bank bank)
        {
            _bankStore.AddBank(bank);

            var response = Request.CreateResponse<Bank>(HttpStatusCode.Created, bank);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = bank.BIC }));

            return response;
        }

        public void PutBank(string id, Bank bank)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage DeleteBank(string id)
        {
            _bankStore.DeleteBank(id);

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
