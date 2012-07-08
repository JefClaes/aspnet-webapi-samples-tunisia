using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples._2.Server.Models
{
    public interface IResumeStore
    {
        IEnumerable<Resume> GetAll();

        Resume GetById(string id);

        void AddResume(Resume resume);        

        bool UpdateResume(string id, Resume resume);        

        void DeleteResume(string id);
        
    }
}
