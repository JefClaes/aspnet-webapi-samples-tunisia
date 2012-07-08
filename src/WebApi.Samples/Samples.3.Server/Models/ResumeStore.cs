using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples._3.Server.Models
{
    public class ResumeStore : IResumeStore
    {
        private static List<Resume> _resumes = new List<Resume>()
        {
            new Resume() { Id = "1", FirstName = "Jef", LastName = "Claes", Skills = null },
            new Resume() { Id = "2", FirstName = "Christophe", LastName = "Geers", Skills = null },
        };

        public IEnumerable<Resume> GetAll()
        {
            return _resumes;
        }

        public Resume GetById(string id)
        {
            return _resumes.Where(r => r.Id == id).FirstOrDefault();
        }

        public void AddResume(Resume resume)
        {
            var id = Guid.NewGuid().ToString();

            resume.Id = id;
            _resumes.Add(resume);            
        }

        public bool UpdateResume(string id, Resume resume)
        {
            int index = _resumes.FindIndex(r => r.Id == resume.Id);
            if (index == -1)            
                return false;
            
            _resumes.RemoveAt(index);
            _resumes.Add(resume);
            
            return true;
        }

        public void DeleteResume(string id)
        {
            _resumes.RemoveAll(r => r.Id == id);
        }
    }
}
