using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Repositories;
using Mmu.Kms.DomainServices.Areas.Services;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Services.Implementation
{
    public class FileService : IFileService
    {
        private readonly IDirectoryStructureService _directoryServiceService;
        private readonly IMapper _mapper;
        private readonly IFileRepository _fileRepository;

        public FileService(IDirectoryStructureService directoryServiceService, IMapper mapper, IFileRepository fileRepository)
        {
            _directoryServiceService = directoryServiceService;
            _mapper = mapper;
            _fileRepository = fileRepository;
        }

        public async Task<IReadOnlyCollection<DirectoryDto>> SearchFilesAsync(FileSearchParametersDto parametersDto)
        {
            var parameters = _mapper.Map<FileSearchParameters>(parametersDto);
            var directories = await _directoryServiceService.SearchFilesAsync(parameters);

            var result = _mapper.Map<List<DirectoryDto>>(directories);
            return result;
        }

        public async Task<FileDto> LoadFileAsync(string filePath)
        {
            var file = await _fileRepository.LoadbyFilePathAsync(filePath);
            var result = _mapper.Map<FileDto>(file);
            return result;
        }
    }
}