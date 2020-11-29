using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApp.Services.Admin.Models
{
    public class AdminServiceDownloadModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] Document { get; set; }
    }
}
