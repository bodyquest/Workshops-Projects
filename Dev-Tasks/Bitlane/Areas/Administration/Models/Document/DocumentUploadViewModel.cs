using DevApp.Common.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static DevApp.Common.GlobalConstants;

namespace DevApp.Areas.Administration.Models.Document
{
    public class DocumentUploadViewModel
    {
        [Required(ErrorMessage = titleIsRequired)]
        public string Title { get; set; }

        [Required(ErrorMessage = firstNameIsRequired)]
        public string CreatorFirstName { get; set; }

        [Required(ErrorMessage = lastNameIsRequired)]
        public string CreatorLastName { get; set; }

        [Required(ErrorMessage = fileRequired)]
        [DataType(DataType.Upload)]
        [MaxFileSize(DocumentMaxSize)]
        public IFormFile Document { get; set; }
    }
}
