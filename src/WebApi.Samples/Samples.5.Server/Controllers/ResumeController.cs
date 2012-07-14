using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Samples.Common;

namespace Samples._5.Server.Controllers
{    
    public class ResumeController : ApiController
    {
        private static IResumeStore _store;

        public ResumeController(IResumeStore resumeStore)
        {
            _store = resumeStore;
        }

        public IEnumerable<Resume> GetResumes()
        {
            return _store.GetAll();
        }

        public Resume GetById(string id)
        {
            return _store.GetById(id);
        }

        public HttpResponseMessage PostResume(Resume resume)
        {
            _store.AddResume(resume);
            var response = Request.CreateResponse<Resume>(HttpStatusCode.Created, resume);

            string uri = Url.Link("DefaultApi", new { id = resume.Id});
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public void PutResume(string id, Resume resume)
        {
            resume.Id = id;

            _store.UpdateResume(id, resume);
        }

        public HttpResponseMessage DeleteResume(string id)
        {
            _store.DeleteResume(id);            

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
