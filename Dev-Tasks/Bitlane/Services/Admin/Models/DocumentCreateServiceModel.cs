using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApp.Services.Admin.Models
{
    public class DocumentCreateServiceModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public byte[] Document { get; set; }
    }
}
