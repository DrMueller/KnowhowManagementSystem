using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Services
{
    public interface IFolderEntrySearchService
    {
        Task<IReadOnlyCollection<FolderEntryViewModel>> SearchFolderEntriesAsync(FileSearchParametersDto parametersDto);
    }
}