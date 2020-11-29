using DevApp.Areas.Administration.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApp.Areas.Administration.Models.Dashboard
{
    public class AdminDashboardModel
    {
        public IEnumerable<DocumentDashboardListingModel> Documents { get; set; }
    }
}
