using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Kms.Application.Areas.Domain.Dtos;
using Mmu.Kms.DomainServices.Areas.Factories;
using Mmu.Kms.DomainServices.Areas.Repositories;

namespace Mmu.Kms.Application.Areas.Domain.Services.Implementation
{
    public class FileTagDataService : IFileTagDataService
    {
        private readonly IFileTagFactory _fileTagFactory;
        private readonly IFileTagRepository _fileTagRepository;
        private readonly IMapper _mapper;

        public FileTagDataService(
            IMapper mapper,
            IFileTagRepository fileTagRepository,
            IFileTagFactory fileTagFactory)
        {
            _mapper = mapper;
            _fileTagRepository = fileTagRepository;
            _fileTagFactory = fileTagFactory;
        }

        public async Task<IReadOnlyCollection<FileTagDto>> LoadAllAsync()
        {
            var fileTags = await _fileTagRepository.LoadAllAsync();
            var result = fileTags.Select(_mapper.Map<FileTagDto>).ToList();
            return result;
        }

        public async Task<FileTagDto> LoadAsync(string id)
        {
            var fileTag = await _fileTagRepository.LoadByIdAsync(id);
            return _mapper.Map<FileTagDto>(fileTag);
        }

        public async Task SaveAsync(FileTagDto dto)
        {
            var fileTag = _fileTagFactory.CreateFileTag(dto.Name, dto.Description, dto.Id);
            await _fileTagRepository.SaveAsync(fileTag);
        }

        public async Task DeleteAsync(string id)
        {
            await _fileTagRepository.DeleteAsync(id);
        }
    }
}