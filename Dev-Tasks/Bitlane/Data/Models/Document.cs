using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static DevApp.Common.GlobalConstants;

namespace DevApp.Data.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [MaxLength(DocumentMaxSize)]
        public byte[] DocumentContent { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
