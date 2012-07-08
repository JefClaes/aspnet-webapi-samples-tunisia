using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Samples.Common;
using System.Net.Http.Formatting;

namespace Samples._4.Server
{    
    public class ResumeController : ApiController
    {
        private readonly IResumeStore _store;

        public ResumeController()
        {
            _store = new ResumeStore();
        }

        public IEnumerable<Resume> GetResumes()
        {
            return _store.GetAll();
        }

        public HttpResponseMessage GetById(string id)
        {
            var resume = _store.GetById(id);

            // Doing content negotiation by hand it by hand
            IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();

            ContentNegotiationResult result = negotiator.Negotiate(
                    typeof(Resume), this.Request, this.Configuration.Formatters);
            if (result == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                throw new HttpResponseException(response);
            }

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<Resume>(
                    resume,                    // What we are serializing 
                    result.Formatter,           // The media formatter
                    result.MediaType.MediaType  // The MIME type
                )
            };          
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
            
            if (!_store.UpdateResume(id, resume))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        public HttpResponseMessage DeleteResume(string id)
        {
            _store.DeleteResume(id);

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
