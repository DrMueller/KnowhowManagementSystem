using System.Collections.Generic;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Services
{
    public interface IDirectoryViewModelFactory
    {
        IReadOnlyCollection<DirectoryViewModel> Create(DirectoryStructureDto directoryStructure);
    }
}