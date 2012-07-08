﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Samples.Common;

namespace Samples._1.Server.Controllers
{    
    public class ResumeController : ApiController
    {
        private static ResumeStore _store = new ResumeStore();

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
