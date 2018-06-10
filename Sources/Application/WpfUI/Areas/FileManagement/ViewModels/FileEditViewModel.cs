using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services;
using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels.ViewModelCommands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FileEditViewModel : ViewModelBase, IInitializableViewModel
    {
        private readonly FileEditViewModelCommands _commands;
        private readonly IFileTagDataService _fileTagDataService;
        private readonly IViewModelFactory _viewModelFactory;
        private ObservableCollection<FileTagDto> _addedFileTags;
        private IReadOnlyCollection<FileTagDto> _allFileTags;
        private FileDto _file;
        private FileTagDisplayViewModel _fileTagDisplayViewModel;
        private FileTagDto _selectedFileTagToToAdd;

        public FileEditViewModel(FileEditViewModelCommands commands, IFileTagDataService fileTagDataService, IViewModelFactory viewModelFactory)
        {
            _commands = commands;
            _fileTagDataService = fileTagDataService;
            _viewModelFactory = viewModelFactory;
        }

        public ObservableCollection<FileTagDto> AddedFileTags
        {
            get => _addedFileTags;
            set
            {
                _addedFileTags = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddFileTagCommand => _commands.AddFileTagCommand;

        public IReadOnlyCollection<FileTagDto> AllFileTags
        {
            get => _allFileTags;
            set
            {
                _allFileTags = value;
                OnPropertyChanged();
            }
        }

        public ICommand CancelCommand => _commands.CancelCommand;

        public FileDto File
        {
            get => _file;
            set
            {
                _file = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AddedFileTags));
            }
        }

        public FileTagDisplayViewModel FileTagDisplayViewModel
        {
            get => _fileTagDisplayViewModel;
            set
            {
                _fileTagDisplayViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => _commands.SaveCommand;

        public FileTagDto SelectedFileTagToAdd
        {
            get => _selectedFileTagToToAdd;
            set
            {
                _selectedFileTagToToAdd = value;
                OnPropertyChanged();
            }
        }

        public async Task InitializeAsync()
        {
            await _commands.InitializeAsync(this);
            AllFileTags = await _fileTagDataService.LoadAllAsync();
        }

        public async Task InitializeFileAsync(FileDto file)
        {
            File = file;
            AddedFileTags = new ObservableCollection<FileTagDto>(File.Tags);
            FileTagDisplayViewModel = await _viewModelFactory.CreateAsync<FileTagDisplayViewModel>();
            FileTagDisplayViewModel.FileTags = AddedFileTags;
        }
    }
}