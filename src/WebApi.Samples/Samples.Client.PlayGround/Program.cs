using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Collections;
using Samples.Common;

namespace Samples.Client.PlayGround
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
            PostResume();

            Console.ReadLine();
        }

        static void PostResume()
        {
            var message = _httpClient.PostAsJsonAsync<Resume>("api/resume", new Resume("Test", "Test"));

            message.Result.EnsureSuccessStatusCode();
            Console.WriteLine(message.Result.Headers.Location.AbsoluteUri);
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
