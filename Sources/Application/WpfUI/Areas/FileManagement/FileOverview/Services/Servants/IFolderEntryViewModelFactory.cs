using System.Collections.Generic;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Services.Servants
{
    public interface IFolderEntryViewModelFactory
    {
        IReadOnlyCollection<FolderEntryViewModel> Create(IReadOnlyCollection<DirectoryDto> dtos);
    }
}