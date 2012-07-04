using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Collections;
using Samples._1.Server.Models;

namespace Samples._1.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8080");

            var result = httpClient.GetAsync("api/resume").Result;

            result.EnsureSuccessStatusCode();
            var resumes = result.Content.ReadAsAsync<IEnumerable<Resume>>().Result;

            foreach (var resume in resumes)
                Console.WriteLine(resume.FirstName + " " + resume.LastName);

            Console.ReadLine();
        }
    }
}
