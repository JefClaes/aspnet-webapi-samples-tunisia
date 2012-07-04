using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using Samples._1.Server.Models;
using System.Net.Http;
using System.Net;

namespace Samples._1.Server.Controllers
{
    // TODO: Implement real store/repository
    public class ResumeController : ApiController
    {
        public IEnumerable<Resume> GetResumes()
        {
            return new List<Resume>() { 
                new Resume() { FirstName = "Jef", LastName = "Claes", Skills = null },
                new Resume() { FirstName = "Christophe", LastName = "Geers", Skills = null }
            };
        }

        public Resume GetById(int id)
        {            
            return new Resume() { FirstName = "Jef", LastName = "Claes", Skills = null };
        }

        public HttpResponseMessage PostResume(Resume resume)
        {         
            var item = resume;
            var response = Request.CreateResponse<Resume>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = 1});
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public void PutResume(string id, Resume resume)
        {
            resume.Id = id;

            var notFound = false;

            if (notFound)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        public HttpResponseMessage DeleteResume(int id)
        {         
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
