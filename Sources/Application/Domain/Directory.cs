using System.Collections.Generic;

namespace Mmu.Kms.Domain
{
    public class Directory
    {
        public Directory(string path, string directoryName, IReadOnlyCollection<Directory> subDirectories, IReadOnlyCollection<File> files)
        {
            Path = path;
            DirectoryName = directoryName;
            SubDirectories = subDirectories;
            Files = files;
        }

        public string DirectoryName { get; }
        public IReadOnlyCollection<File> Files { get; }
        public string Path { get; }
        public IReadOnlyCollection<Directory> SubDirectories { get; }
    }
}