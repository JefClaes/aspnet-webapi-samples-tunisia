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
        private static HttpClient _httpClient;

        static void Main(string[] args)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080");

            GetAll();
            GetById();

            Console.ReadLine();
        }

        static void GetById()
        {
            var result = _httpClient.GetAsync("api/resume/1").Result;

            result.EnsureSuccessStatusCode();

            var resume = result.Content.ReadAsAsync<Resume>().Result;

            Console.WriteLine(resume.FirstName + " " + resume.LastName);
        }

        static void GetAll()
        {
            var result = _httpClient.GetAsync("api/resume").Result;

            result.EnsureSuccessStatusCode();

            foreach (var resume in result.Content.ReadAsAsync<IEnumerable<Resume>>().Result)
                Console.WriteLine(resume.FirstName + " " + resume.LastName);
        }
    }
}
