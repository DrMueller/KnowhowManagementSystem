using Mmu.Kms.Application.Areas.Domain.Common.Dtos;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos
{
    public class FileSearchParametersDto
    {
        public string FileContent { get; set; }
        public string FileName { get; set; }
        public FileTagDto FileTag { get; set; }
        public FileTypeDto FileType { get; set; }
        public string RootPath { get; set; }
    }
}