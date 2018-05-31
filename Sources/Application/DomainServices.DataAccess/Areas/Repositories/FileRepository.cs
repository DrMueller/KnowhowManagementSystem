using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Factories;
using Mmu.Kms.DomainServices.Areas.Repositories;
using Mmu.Kms.DomainServices.DataAccess.Areas.Factories;
using Mmu.Kms.DomainServices.DataAccess.Areas.Services;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IShadowFileService _shadowFileService;
        private readonly IFileContentFactory _fileContentFactory;
        private readonly IFileTagRepository _fileTagRepository;

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
            var shadowFile = _shadowFileService.GetOrCreateShadowFile(filePath);
            var tags = await _fileTagRepository.LoadAsyncByNames(shadowFile.TagNames);

            return new Domain.File(
                fileInfo.FullName,
                fileInfo.Name,
                _fileContentFactory.CreateFromFile(filePath),
                FileType.All.First(f => f.Extension == fileInfo.Extension.ToUpperInvariant()),
                tags);
        }

        private void SaveFile(Domain.File file)
        {
            var fileInfo = new FileInfo(Path.Combine(file.DirectoryPath, file.FileName));
            var shadowFile = _shadowFileService.GetOrCreateShadowFile(fileInfo.FullName);
            shadowFile.TagNames = file.Tags.Select(f => f.Name).ToList();

            // TODO newtonsoft and save

        }
    }
}