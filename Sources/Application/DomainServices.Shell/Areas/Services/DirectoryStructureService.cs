using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Repositories;
using Mmu.Kms.DomainServices.Areas.Services;
using Mmu.Kms.DomainServices.Shell.Areas.DataModels;
using Mmu.Kms.DomainServices.Shell.Areas.Services.Servants;

namespace Mmu.Kms.DomainServices.Shell.Areas.Services
{
    public class DirectoryStructureService : IDirectoryStructureService
    {
        private readonly IDirectoryServant _directoryServant;
        private readonly IFileRepository _fileRepository;

        public DirectoryStructureService(IFileRepository fileRepository, IDirectoryServant directoryServant)
        {
            _fileRepository = fileRepository;
            _directoryServant = directoryServant;
        }

        public async Task<IReadOnlyCollection<Directory>> SearchFilesAsync(FileSearchParameters parameters)
        {
            var directoryDataModels = await _directoryServant.SearchFilesAsync(parameters);
            var result = directoryDataModels.Select(AdaptDirectory).ToList();

            return result;
        }

        private static Directory AdaptDirectory(DirectoryDataModel directoryDataModel)
        {
            var subDirectories = directoryDataModel.SubDirectories.Select(AdaptDirectory).ToList();
            var files = directoryDataModel.Files.Select(AdaptFile).ToList();

            var result = new Directory(
                directoryDataModel.Path,
                directoryDataModel.DirectoryName,
                subDirectories,
                files);

            return result;
        }

        private static File AdaptFile(FileDataModel fileDataModel) => new File(
            fileDataModel.FilePath,
            fileDataModel.FileName,
            new FileContent(fileDataModel.Content),
            FileType.CreateFromExtension(fileDataModel.FileExtension),
            new List<FileTag>());
    }
}