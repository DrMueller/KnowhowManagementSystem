using System.Collections.Generic;
using System.Linq;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Services.Implementation
{
    public class DirectoryViewModelFactory : IDirectoryViewModelFactory
    {
        private readonly IStructureEntryIconFactory _structureEntryIconFactory;

        public DirectoryViewModelFactory(IStructureEntryIconFactory structureEntryIconFactory)
        {
            _structureEntryIconFactory = structureEntryIconFactory;
        }

        public IReadOnlyCollection<DirectoryViewModel> Create(DirectoryStructureDto directoryStructure)
        {
            var root = new DirectoryViewModel(string.Empty, string.Empty);

            foreach (var directory in directoryStructure.Directories)
            {
                CreateTreeViewItemsRecursive(directory, root);
            }

            return root.SubDirectories;
        }

        private void CreateTreeViewItemsRecursive(DirectoryDto directory, DirectoryViewModel parentDirectoryVm)
        {
            var directoryVm = CreateFromDirectory(directory);
            directoryVm.Files = directory.Files.Select(CreateFromFile).ToList();

            parentDirectoryVm.SubDirectories.Add(directoryVm);

            foreach (var subDirectory in directory.SubDirectories)
            {
                CreateTreeViewItemsRecursive(subDirectory, directoryVm);
            }
        }

        private DirectoryViewModel CreateFromDirectory(DirectoryDto directory) => new DirectoryViewModel(
            directory.DirectoryName,
            _structureEntryIconFactory.CreateIconPathForDirectory());

        private FileViewModel CreateFromFile(FileDto file) => new FileViewModel(
            file.FileName,
            file.FilePath,
            _structureEntryIconFactory.CreateIconPathForFile(file.FileType),
            string.Join(", ", file.Tags));
    }
}