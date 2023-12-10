using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOAPI.Models
{
    public class ContactForm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Message { get; set; }

    }
    public class Result
    {
        public string Status { get; set; }
        public dynamic Data { get; set; }
    }

}
