using System.Collections.Generic;

namespace Mmu.Kms.Domain
{
    public class DirectoryStructure
    {
        public DirectoryStructure(IReadOnlyCollection<Directory> directories)
        {
            Directories = directories;
        }

        public IReadOnlyCollection<Directory> Directories { get; }
    }
}