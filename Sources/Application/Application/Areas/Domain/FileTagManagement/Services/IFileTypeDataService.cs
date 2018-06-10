using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;

namespace Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services
{
    public interface IFileTypeDataService
    {
        Task<IReadOnlyCollection<FileTypeDto>> LoadAllAsync();
    }
}