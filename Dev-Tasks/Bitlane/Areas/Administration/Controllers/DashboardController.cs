using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevApp.Services.Admin;
using DevApp.Services.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IAdminDocumentService documentService;

        public DashboardController(IAdminDocumentService documentService)
        {
            this.documentService = documentService;
        }

        // GET: Dashboard Index
        public async Task<IActionResult> Index()
        {
            var model = await this.documentService.GetDocsAsync();
            var viewModel = new DashboardViewModel
            {
                Docs = model
            };

            return View(viewModel);
        }

        // GET: Search
        public async Task<IActionResult> Search(string searchQuery)
        {
            var model = await this.documentService.FindAsync(searchQuery.ToLower());

            if (model == null)
            {
                return this.RedirectToAction("Index", "Dashboard", new { area = "Administration" });
            }

            var viewModel = new DashboardViewModel
            {
                Docs = model
            };

            return this.View(viewModel);
        }
    }
}