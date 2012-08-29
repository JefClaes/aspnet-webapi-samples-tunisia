using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApi.EuricomCruise.Samples.Server
{
    public class BankStore 
    {
        private static List<Bank> _banks = new List<Bank>()
        {
            new Bank() { BIC = "1", Name = "KBC" },
            new Bank() { BIC = "2", Name = "Belfius" }
        };

        public IEnumerable<Bank> GetAll()
        {
            return _banks;
        }

        public Bank GetById(string id)
        {
            return _banks.Where(r => r.BIC == id).FirstOrDefault();
        }

        public void AddBank(Bank bank)
        {          
            _banks.Add(bank);
        }

        public bool UpdateBank(string id, Bank bank)
        {
            int index = _banks.FindIndex(r => r.BIC == bank.BIC);
            if (index == -1)
                return false;

            _banks.RemoveAt(index);
            _banks.Add(bank);

            return true;
        }

        public void DeleteBank(string id)
        {
            _banks.RemoveAll(r => r.BIC == id);
        }
    }
}
