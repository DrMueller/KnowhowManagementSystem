using System.Collections.Generic;
using System.Linq;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Models;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Services.Servants.Implementation
{
    public class FolderEntryViewModelFactory : IFolderEntryViewModelFactory
    {
        private readonly IStructureEntryIconFactory _structureEntryIconFactory;

        public FolderEntryViewModelFactory(IStructureEntryIconFactory structureEntryIconFactory)
        {
            _structureEntryIconFactory = structureEntryIconFactory;
        }

        public IReadOnlyCollection<FolderEntryViewModel> Create(IReadOnlyCollection<DirectoryDto> dtos)
        {
            var root = new FolderEntryViewModel(FolderEntryViewModelType.Directory, string.Empty, string.Empty, string.Empty, string.Empty);
            var sortedDtos = dtos.OrderBy(f => f.DirectoryName);

            foreach (var directory in sortedDtos)
            {
                CreateTreeViewItemsRecursive(directory, root, true);
            }

            return root.SubEntries;
        }

        private void CreateTreeViewItemsRecursive(DirectoryDto directory, FolderEntryViewModel parentVm, bool isTopLevel)
        {
            var directoryVm = CreateFromDirectory(directory, isTopLevel);

            // Add the Files as SubEntries
            var fileViewModels = directory
                .Files
                .Select(CreateFromFile)
                .OrderBy(f => f.Name)
                .ToList();

            directoryVm.SubEntries.AddRange(fileViewModels);

            // Add the Directory as SubEntry
            parentVm.SubEntries.Add(directoryVm);

            foreach (var subDirectory in directory.SubDirectories)
            {
                CreateTreeViewItemsRecursive(subDirectory, directoryVm, false);
            }
        }

        private FolderEntryViewModel CreateFromDirectory(DirectoryDto directory, bool isTopLevel) => new FolderEntryViewModel(
            FolderEntryViewModelType.Directory,
            isTopLevel ? directory.Path : directory.DirectoryName,
            directory.Path,
            _structureEntryIconFactory.CreateIconPathForDirectory(),
            string.Empty);

        private FolderEntryViewModel CreateFromFile(FileDto file) => new FolderEntryViewModel(
            FolderEntryViewModelType.File,
            file.FileName,
            file.FilePath,
            _structureEntryIconFactory.CreateIconPathForFile(file.FileType),
            string.Join(", ", file.Tags));
    }
}