using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Services
{
    public interface IFileService
    {
        Task<IReadOnlyCollection<DirectoryDto>> SearchFilesAsync(FileSearchParametersDto parametersDto);

        Task<FileDto> LoadFileAsync(string filePath);
    }
}