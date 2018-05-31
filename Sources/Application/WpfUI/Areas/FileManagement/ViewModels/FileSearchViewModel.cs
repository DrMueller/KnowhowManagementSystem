using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Repositories;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FileSearchViewModel : ViewModelBase, IInitializableViewModel
    {
        private readonly IFileTagRepository _fileTagRepository;

        public FileSearchViewModel(IFileTagRepository fileTagRepository)
        {
            _fileTagRepository = fileTagRepository;
        }

        public IReadOnlyCollection<FileTag> FileTags { get; private set; }
        public IReadOnlyCollection<FileType> FileTypes => FileType.All;
        public Action<FileSearchParameters> SearchCallback { get; set; }
        public string SelectedFileContent { get; set; }
        public string SelectedFileName { get; set; }
        public FileTag SelectedFileTag { get; set; }
        public FileType SelectedFileType { get; set; }
        public string SelectedRootPath { get; set; }

        public async Task InitializeAsync()
        {
            FileTags = await _fileTagRepository.LoadAllAsync();
            SelectedRootPath = @"C:\Users\matthias.mueller\Dropbox";
        }

        public void SearchClicked()
        {
            var fileSearchParameters = new FileSearchParameters(SelectedRootPath, SelectedFileName, SelectedFileContent, null, null);
            SearchCallback(fileSearchParameters);
        }
    }
}