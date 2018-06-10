using System.Linq;
using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Repositories;

namespace Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services.Implementation
{
    public class FileDataService : IFileDataService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileTagRepository _fileTagRepository;

        public FileDataService(IFileRepository fileRepository, IFileTagRepository fileTagRepository)
        {
            _fileRepository = fileRepository;
            _fileTagRepository = fileTagRepository;
        }

        public async Task SaveAsync(FileDto dto)
        {
            var ids = dto.Tags.Select(f => f.Id).ToList();
            var fileTags = await _fileTagRepository.LoadByIdsAsync(ids);

            var file = new File(
                dto.FilePath,
                dto.FileName,
                new FileContent(dto.Content.Content),
                FileType.All.First(f => f.Extension == dto.FileType.Extension),
                fileTags);

            _fileRepository.SaveFiles(new[] { file });
        }
    }
}