using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApp.Services.Admin.Models
{
    public class AdminDocumentListingServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Created { get; set; }

        public string CreatorFirstName { get; set; }

        public string CreatorLastName { get; set; }
    }
}
