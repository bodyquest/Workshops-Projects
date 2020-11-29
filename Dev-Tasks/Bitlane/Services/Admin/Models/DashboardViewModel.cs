using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApp.Services.Admin.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<AdminDocumentListingServiceModel> Docs { get; set; }
    }
}
