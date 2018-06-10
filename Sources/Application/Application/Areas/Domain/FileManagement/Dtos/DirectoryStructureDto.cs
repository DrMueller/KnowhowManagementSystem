using System.Collections.Generic;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos
{
    public class DirectoryStructureDto
    {
        public IReadOnlyCollection<DirectoryDto> Directories { get; set; }
    }
}