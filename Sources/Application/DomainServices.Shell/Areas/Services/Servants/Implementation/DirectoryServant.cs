using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Shell.Areas.DataModels;

namespace Mmu.Kms.DomainServices.Shell.Areas.Services.Servants.Implementation
{
    internal class DirectoryServant : IDirectoryServant
    {
        public async Task<IReadOnlyCollection<DirectoryDataModel>> SearchFilesAsync(FileSearchParameters parameters)
        {
            var directoryInfos = System.IO.Directory.EnumerateDirectories(parameters.RootPath, "*", SearchOption.AllDirectories)
                .Select(f => new DirectoryInfo(f));

            var directories = await Task.Run(
                () =>
                {
                    return directoryInfos.AsParallel()
                        .Select(di => Adapt(di, parameters))
                        .ToList();
                });

            RemoveEmptyDirectories(directories);
            return directories;
        }

        private static void RemoveEmptyDirectories(List<DirectoryDataModel> directories)
        {
            while (true)
            {
                var itemsRemoved = directories.Any(f => f.RemoveEmptySubDirectories());
                itemsRemoved = directories.RemoveAll(f => f.IsEmpty) > 0 || itemsRemoved;
                if (itemsRemoved)
                {
                    continue;
                }

                return;
            }
        }

        private static DirectoryDataModel Adapt(DirectoryInfo directoryInfo, FileSearchParameters parameters)
        {
            var subDirectories = directoryInfo.GetDirectories().Select(di => Adapt(di, parameters)).ToList();

            var fileInfos = directoryInfo.EnumerateFiles("*", SearchOption.TopDirectoryOnly);

            if (!string.IsNullOrEmpty(parameters.FileName))
            {
                fileInfos = fileInfos.Where(f => f.Name.IndexOf(parameters.FileName, StringComparison.OrdinalIgnoreCase) > -1);
            }

            if (parameters.FileType != null)
            {
                fileInfos = fileInfos.Where(f => f.Extension.ToUpperInvariant() == parameters.FileType.Extension);
            }

            var files = fileInfos.Select(
                f => new FileDataModel
                {
                    FileExtension = f.Extension,
                    FileName = f.Name,
                    FilePath = f.FullName,
                    Content = string.Empty
                });

            var result = new DirectoryDataModel(
                directoryInfo.FullName,
                directoryInfo.Name,
                subDirectories,
                files.ToList());

            return result;
        }
    }
}