using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Services;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Services.Servants;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Services.Implementation
{
    public class FolderEntrySearchService : IFolderEntrySearchService
    {
        private readonly IFileService _fileService;
        private readonly IFolderEntryViewModelFactory _folderEntryViewModelFactory;

        public FolderEntrySearchService(IFolderEntryViewModelFactory folderEntryViewModelFactory, IFileService fileService)
        {
            _folderEntryViewModelFactory = folderEntryViewModelFactory;
            _fileService = fileService;
        }

        public async Task<IReadOnlyCollection<FolderEntryViewModel>> SearchFolderEntriesAsync(FileSearchParametersDto parametersDto)
        {
            var directoryDtos = await _fileService.SearchFilesAsync(parametersDto);
            var result = _folderEntryViewModelFactory.Create(directoryDtos);

            return result;
        }
    }
}