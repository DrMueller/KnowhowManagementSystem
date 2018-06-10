using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Services;
using Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services;
using Mmu.Kms.WpfUI.Areas.FileManagement.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FilesOverviewViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private readonly IFileService _fileService;
        private readonly IFileTagDataService _fileTagDataService;
        private readonly IFileTypeDataService _fileTypeDataService;
        private readonly IFileEditService _fileEditService;
        private readonly IViewModelFactory _viewModelFactory;
        private DirectoryStructureDto _directoryStructure;
        private IReadOnlyCollection<FileTagDto> _fileTags;
        private IReadOnlyCollection<FileTypeDto> _fileTypes;

        public FilesOverviewViewModel(
            IFileService fileService,
            IFileTagDataService fileTagDataService,
            IFileTypeDataService fileTypeDataService,
            IFileEditService fileEditService,
            IViewModelFactory viewModelFactory)
        {
            _fileService = fileService;
            _fileTagDataService = fileTagDataService;
            _fileTypeDataService = fileTypeDataService;
            _fileEditService = fileEditService;
            _viewModelFactory = viewModelFactory;
        }

        public FileManagementViewModel FileManagementViewModel { get; private set; }

        public DirectoryStructureDto DirectoryStructure
        {
            get => _directoryStructure;
            private set
            {
                _directoryStructure = value;
                FileManagementViewModel.DirectoryStructure = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<FileTagDto> FileTags
        {
            get => _fileTags;
            set
            {
                _fileTags = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<FileTypeDto> FileTypes
        {
            get => _fileTypes;
            set
            {
                _fileTypes = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new ParametredRelayCommand(
                    async searchFileParams =>
                    {
                        DirectoryStructure = await _fileService.SearchFilesAsync((FileSearchParametersDto)searchFileParams);
                    });
            }
        }

        public ICommand EditFileCommand
        {
            get
            {
                return new ParametredRelayCommand(
                    async file =>
                    {
                        await _fileEditService.EditFileAsync((FileDto)file);
                    });
            }
        }

        public async Task InitializeAsync()
        {
            FileManagementViewModel = await _viewModelFactory.CreateAsync<FileManagementViewModel>();
            FileTags = await _fileTagDataService.LoadAllAsync();
            FileTypes = await _fileTypeDataService.LoadAllAsync();
        }

        public string NavigationDescription { get; } = "Files";
        public int NavigationSequence { get; } = 1;
        public string HeadingText { get; } = "Files Overview";
    }
}