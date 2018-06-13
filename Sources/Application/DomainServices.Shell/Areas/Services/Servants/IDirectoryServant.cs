using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Shell.Areas.DataModels;

namespace Mmu.Kms.DomainServices.Shell.Areas.Services.Servants
{
    public interface IDirectoryServant
    {
        Task<IReadOnlyCollection<DirectoryDataModel>> SearchFilesAsync(FileSearchParameters parameters);
    }
}