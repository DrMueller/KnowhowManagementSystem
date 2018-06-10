using System.Threading.Tasks;
using AutoMapper;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Services;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Services.Implementation
{
    public class FileService : IFileService
    {
        private readonly IDirectoryStructureService _directoryServiceService;
        private readonly IMapper _mapper;

        public FileService(IDirectoryStructureService directoryServiceService, IMapper mapper)
        {
            _directoryServiceService = directoryServiceService;
            _mapper = mapper;
        }

        public async Task<DirectoryStructureDto> SearchFilesAsync(FileSearchParametersDto parametersDto)
        {
            var parameters = _mapper.Map<FileSearchParameters>(parametersDto);
            var directoryStructure = await _directoryServiceService.SearchFilesAsync(parameters);

            var result = _mapper.Map<DirectoryStructureDto>(directoryStructure);
            return result;
        }
    }
}