using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Repositories;
using Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Dtos;
using Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Factories;
using Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Services;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IFileContentFactory _fileContentFactory;
        private readonly IFileTagRepository _fileTagRepository;
        private readonly IShadowFileService _shadowFileService;

        public FileRepository(
            IShadowFileService shadowFileService,
            IFileContentFactory fileContentFactory,
            IFileTagRepository fileTagRepository)
        {
            _shadowFileService = shadowFileService;
            _fileContentFactory = fileContentFactory;
            _fileTagRepository = fileTagRepository;
        }

        public void SaveFiles(IReadOnlyCollection<Domain.File> files)
        {
            foreach (var file in files)
            {
                SaveFile(file);
            }
        }

        public async Task<Domain.File> LoadbyFilePathAsync(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            var shadowFile = _shadowFileService.LoadShadowFile(filePath);

            var tags = await LoadTagsAsync(shadowFile);

            return new Domain.File(
                fileInfo.FullName,
                fileInfo.Name,
                _fileContentFactory.CreateFromFile(filePath),
                FileType.All.FirstOrDefault(f => f.Extension == fileInfo.Extension.ToUpperInvariant()) ?? FileType.Unknown,
                tags);
        }

        private async Task<IReadOnlyCollection<FileTag>> LoadTagsAsync(ShadowFileDto shadowFile)
        {
            if (!shadowFile.TagNames.Any())
            {
                return new List<FileTag>();
            }

            return await _fileTagRepository.LoadAsyncByNames(shadowFile.TagNames);
        }

        private void SaveFile(Domain.File file)
        {
            var shadowFile = _shadowFileService.LoadShadowFile(file.FilePath);
            shadowFile.TagNames = file.Tags.Select(f => f.Name).ToList();
            _shadowFileService.SaveShadowFile(file.FilePath, shadowFile);
        }
    }
}