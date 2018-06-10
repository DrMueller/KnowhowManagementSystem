using System.Collections.Generic;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos
{
    public class DirectoryDto
    {
        public string DirectoryName { get; set; }
        public IReadOnlyCollection<FileDto> Files { get; set; }
        public string Path { get; set; }
        public IReadOnlyCollection<DirectoryDto> SubDirectories { get; set; }
    }
}