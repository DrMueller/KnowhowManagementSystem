using System.Collections.Generic;
using System.Linq;

namespace Mmu.Kms.DomainServices.Shell.Areas.DataModels
{
    public class DirectoryDataModel
    {
        private List<DirectoryDataModel> _subDirectories;

        public DirectoryDataModel(string path, string directoryName, List<DirectoryDataModel> subDirectories, IReadOnlyCollection<FileDataModel> files)
        {
            Path = path;
            DirectoryName = directoryName;
            _subDirectories = subDirectories;
            Files = files;
        }

        public string DirectoryName { get; }
        public IReadOnlyCollection<FileDataModel> Files { get; }
        public string Path { get; }
        public IReadOnlyCollection<DirectoryDataModel> SubDirectories => _subDirectories;
        public bool IsEmpty => !SubDirectories.Any() && !Files.Any();

        public bool RemoveEmptySubDirectories()
        {
            var itemsRemoved = false;

            foreach (var subdirectory in SubDirectories)
            {
                itemsRemoved = itemsRemoved | subdirectory.RemoveEmptySubDirectories();
            }

            itemsRemoved = itemsRemoved | _subDirectories.RemoveAll(f => f.IsEmpty) > 0;
            return itemsRemoved;
        }
    }
}