using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevApp.Areas.Administration.Models.Document;
using DevApp.Common.Extensions;
using DevApp.Services.Admin;
using DevApp.Services.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DevApp.Common.GlobalConstants;

namespace DevApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize]
    public class DocumentsController : Controller
    {
        private readonly IAdminDocumentService documentService;

        public DocumentsController(IAdminDocumentService documentService)
        {
            this.documentService = documentService;
        }

        // GET: Documents/Details/id
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var model = await this.documentService.GetDocumentDetailsAsync(id);
            var viewModel = new AdminDocumentDownloadViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Document = model.Document
            };

            return View(viewModel);
        }

        // GET: Documents/DowanlodFile/id
        public async Task<IActionResult> DownloadFile(int requestId)
        {
            var model = await this.documentService.GetDocumentDetailsAsync(requestId);

            var documentContent = model.Document;
            if (model.Title.EndsWith("pdf"))
            {
                return this.File(documentContent, "application/pdf", $"{DateTime.UtcNow.ToString("dd-MM-yyyy")} - {model.Title}");
            }
            else if (model.Title.EndsWith("doc"))
            {
                return this.File(documentContent, "application/msword", $"{DateTime.UtcNow.ToString("dd-MM-yyyy")} - {model.Title}");
            }
            else if (model.Title.EndsWith("docx"))
            {
                return this.File(documentContent, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"{DateTime.UtcNow.ToString("dd-MM-yyyy")} - {model.Title}");
            }
            else if (model.Title.EndsWith("xls"))
            {
                return this.File(documentContent, "application/vnd.ms-excel", $"{DateTime.UtcNow.ToString("dd-MM-yyyy")} - {model.Title}");
            }
            else
            {
                return this.File(documentContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{DateTime.UtcNow.ToString("dd-MM-yyyy")} - {model.Title}");
            }
        }

        // GET: Documents/Upload
        [ActionName("Upload")]
        public IActionResult Upload()
        {
            var model = new DocumentUploadViewModel();
            return this.View(model);
        }

        // POST: Documents/Upload
        [HttpPost]
        [ActionName("Upload")]
        public async Task<IActionResult> UploadAsync(string creatorFirstName, string creatorLastName, string title, IFormFile document)
        {
            if (string.IsNullOrWhiteSpace(creatorFirstName)
                || string.IsNullOrWhiteSpace(creatorLastName)
                || string.IsNullOrWhiteSpace(title)
                || document.Length > DocumentMaxSize)
            {
                return this.View();
            }

            var extension = Path.GetExtension(document.FileName);
            var trimmedExt = extension.Substring(1, extension.Length - 1);
            if (extension != ".pdf"
                && extension != ".doc"
                && extension != ".docx"
                && extension != ".xls"
                && extension != ".xlsx")
            {
                return this.View();
            }
            var fileContents = await document.ToByteArrayAsync();
            var modelForDb = new DocumentCreateServiceModel
            {
                FirstName = creatorFirstName,
                LastName = creatorLastName,
                Title = $"{title} - {trimmedExt.ToLower()}",
                Created = DateTime.UtcNow,
                Document = fileContents,
            };

            bool isCreated = await this.documentService.UploadDocumentAsync(modelForDb);

            if (isCreated)
            {
                return this.RedirectToAction("Index", "Dashboard", new { area = "Administration" });
            }
            else
            {
                return this.View();
            }
        }
    }
}