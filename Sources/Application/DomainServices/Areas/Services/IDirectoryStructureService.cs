using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.Areas.Services
{
    public interface IDirectoryStructureService
    {
        Task<DirectoryStructure> SearchFilesAsync(FileSearchParameters parameters);
    }
}