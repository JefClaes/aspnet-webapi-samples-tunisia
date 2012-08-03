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
        private static BankStore _bankStore = new BankStore();
       
        public IEnumerable<Bank> GetBanks()
        {
            return _bankStore.GetAll();
        }

        public Bank GetByIdentifier(string id)
        {
            return _bankStore.GetById(id);
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
            _bankStore.UpdateBank(id, bank);
        }

        public HttpResponseMessage DeleteBank(string id)
        {
            _bankStore.DeleteBank(id);

            return new HttpResponseMessage(HttpStatusCode.);
        }
    }
}
