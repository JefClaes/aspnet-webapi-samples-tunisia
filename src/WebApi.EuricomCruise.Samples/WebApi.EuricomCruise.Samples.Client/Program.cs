using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using WebApi.EuricomCruise.Samples.Server;

namespace WebApi.EuricomCruise.Samples.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");

            client.PostAsXmlAsync<Bank>("api/bank", new Bank() { BIC = "X", Name = "BankX" }).
                ContinueWith((m) => {
                    var location = m.Result.Headers.Location;
                    var getRes = client.GetAsync(location).Result;
                    var bankName = getRes.Content.ReadAsAsync<Bank>().Result.Name;

                    Console.WriteLine("Bankname: " + bankName);            
                });           
            
            Console.ReadLine();            
        }
    }
}
