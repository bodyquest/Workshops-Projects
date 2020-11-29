using DevApp.Data;
using DevApp.Data.Models;
using DevApp.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApp.Services.Admin.Implementations
{
    public class AdminDocumentService : IAdminDocumentService
    {
        private readonly ApplicationDbContext context;

        public AdminDocumentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AdminDocumentListingServiceModel>> GetDocsAsync()
        {
            var model = await this.context.Documents
                .OrderByDescending(x => x.Created)
                .Select(d => new AdminDocumentListingServiceModel
                {
                    Id = d.Id,
                    Title = d.Title,
                    Created = d.Created.ToString("dd/MM/yyyy h:mm tt"),
                    CreatorFirstName = d.FirstName,
                    CreatorLastName = d.LastName
                })
                .Take(10)
                .ToListAsync();

            return model;
        }

        public async Task<bool> UploadDocumentAsync(DocumentCreateServiceModel model)
        {
            var document = new Document
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                Created = model.Created,
                DocumentContent = model.Document
            };

            await this.context.Documents.AddAsync(document);
            int result = await this.context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<AdminDocumentListingServiceModel>> FindAsync(string searchQuery)
        {
            searchQuery = searchQuery ?? string.Empty;

            var model = await this.context.Documents
                .Where(d => d.Title.ToLower().Contains(searchQuery))
                .OrderByDescending(x => x.Created)
                .Select(d => new AdminDocumentListingServiceModel
                {
                    Id = d.Id,
                    Title = d.Title,
                    Created = d.Created.ToString("dd/MM/yyyy h:mm tt"),
                    CreatorFirstName = d.FirstName,
                    CreatorLastName = d.FirstName
                })
                .ToListAsync();

            return model;
        }

        public async Task<AdminServiceDownloadModel> GetDocumentDetailsAsync (int id)
        {
            var model = await this.context.Documents
                .Where(d => d.Id == id)
                .Select(d => new AdminServiceDownloadModel
                {
                    Id = d.Id,
                    Title = d.Title,
                    Document = d.DocumentContent
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<byte[]> GetFileAsync(int requestId)
        {
            var file = await this.context.Documents
                .Where(d => d.Id == requestId)
                .Select(d => d.DocumentContent)
                .FirstOrDefaultAsync();

            return file;
        }
    }
}
