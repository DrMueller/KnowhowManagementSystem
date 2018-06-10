using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.Domain;

namespace Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services.Implementation
{
    public class FileTypeDataService : IFileTypeDataService
    {
        public Task<IReadOnlyCollection<FileTypeDto>> LoadAllAsync()
        {
            IReadOnlyCollection<FileTypeDto> fileTypes = FileType.All.Select(
                f => new FileTypeDto
                {
                    Description = f.Description,
                    Extension = f.Extension
                }).ToList();

            return Task.FromResult(fileTypes);
        }
    }
}