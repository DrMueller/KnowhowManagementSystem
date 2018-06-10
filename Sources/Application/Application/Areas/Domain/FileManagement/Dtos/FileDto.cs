using System.Collections.Generic;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos
{
    public class FileDto
    {
        public FileContentDto Content { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public FileTypeDto FileType { get; set; }
        public IReadOnlyCollection<FileTagDto> Tags { get; set; }
    }
}