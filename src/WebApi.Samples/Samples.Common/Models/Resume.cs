using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.Common
{
    public class Resume
    {
        public Resume(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Website { get; set; }

        public IEnumerable<string> Technologies { get; set; }

        public IEnumerable<string> Experiences { get; set; }        
    }
}
