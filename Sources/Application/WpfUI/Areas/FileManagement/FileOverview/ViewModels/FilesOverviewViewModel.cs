using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels
{
    public class FilesOverviewViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private readonly IFileTagDataService _fileTagDataService;
        private readonly IFileTypeDataService _fileTypeDataService;
        private readonly IFolderEntrySearchService _folderEntrySearchService;
        private readonly IViewModelFactory _viewModelFactory;
        private IReadOnlyCollection<FileTagDto> _fileTags;
        private IReadOnlyCollection<FileTypeDto> _fileTypes;

        public FilesOverviewViewModel(
            IFileTagDataService fileTagDataService,
            IFileTypeDataService fileTypeDataService,
            IViewModelFactory viewModelFactory,
            IFolderEntrySearchService folderEntrySearchService)
        {
            _fileTagDataService = fileTagDataService;
            _fileTypeDataService = fileTypeDataService;
            _viewModelFactory = viewModelFactory;
            _folderEntrySearchService = folderEntrySearchService;
        }

        public FileManagementViewModel FileManagementViewModel { get; private set; }

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

        public string HeadingText { get; } = "Files Overview";
        public string NavigationDescription { get; } = "Files";
        public int NavigationSequence { get; } = 1;

        public ICommand SearchCommand
        {
            get
            {
                return new ParametredRelayCommand(
                    async fileSearchParams =>
                    {
                        FileManagementViewModel.FolderEntries = await _folderEntrySearchService.SearchFolderEntriesAsync((FileSearchParametersDto)fileSearchParams);
                    });
            }
        }

        public async Task InitializeAsync()
        {
            FileManagementViewModel = await _viewModelFactory.CreateAsync<FileManagementViewModel>();
            FileTags = await _fileTagDataService.LoadAllAsync();
            FileTypes = await _fileTypeDataService.LoadAllAsync();
        }
    }
}