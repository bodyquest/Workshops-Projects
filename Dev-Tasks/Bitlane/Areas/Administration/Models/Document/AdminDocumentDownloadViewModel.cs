using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApp.Areas.Administration.Models.Document
{
    public class AdminDocumentDownloadViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] Document { get; set; }
    }
}
