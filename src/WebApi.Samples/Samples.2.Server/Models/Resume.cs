using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples._2.Server.Models
{
    public class Resume
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Skills { get; set; }
    }
}
