using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Repositories;
using Mmu.Kms.DomainServices.Areas.Services;

namespace Mmu.Kms.DomainServices.Shell.Areas.Services
{
    public class DirectoryStructureService : IDirectoryStructureService
    {
        private readonly IFileRepository _fileRepository;

        public DirectoryStructureService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<DirectoryStructure> SearchFilesAsync(FileSearchParameters parameters)
        {
            var files = await SearchFilesAsyncRecursive(parameters);
            var directories = new List<Domain.Directory>
            {
                new Domain.Directory(parameters.RootPath, "Root", new List<Domain.Directory>(), files)
            };

            return new DirectoryStructure(directories);
        }

        private async Task<IReadOnlyCollection<Domain.File>> SearchFilesAsyncRecursive(FileSearchParameters parameters)
        {
            var files = System.IO.Directory.GetFiles(parameters.RootPath, "*", SearchOption.AllDirectories);
            var fileTasks = files.Select(_fileRepository.LoadbyFilePathAsync);
            var fileEntries = await Task.WhenAll(fileTasks);

            return fileEntries
                .Where(f => string.IsNullOrEmpty(parameters.FileContent) || f.Content.Content.ToUpperInvariant().Contains(parameters.FileContent.ToUpperInvariant()))
                .Where(f => string.IsNullOrEmpty(parameters.FileName) || f.FileName.ToUpperInvariant().Contains(parameters.FileName.ToUpperInvariant()))
                .Where(f => parameters.FileTag == null || f.Tags.Contains(parameters.FileTag))
                .Where(f => parameters.FileType == null || f.FileType == parameters.FileType)
                .ToList();
        }
    }
}