using DevApp.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApp.Services.Admin
{
    public interface IAdminDocumentService
    {
        Task<IEnumerable<AdminDocumentListingServiceModel>> GetDocsAsync();

        Task<bool> UploadDocumentAsync(DocumentCreateServiceModel modelForDb);

        Task<IEnumerable<AdminDocumentListingServiceModel>> FindAsync(string searchQuery);

        Task<AdminServiceDownloadModel> GetDocumentDetailsAsync(int id);

        Task<byte[]> GetFileAsync(int requestId);
    }
}
