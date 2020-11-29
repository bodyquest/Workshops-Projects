using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApp.Areas.Administration.Models.Document
{
    public class DocumentDashboardListingModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public string CreatorFirstName { get; set; }

        public string CreatorLastName { get; set; }
    }
}
