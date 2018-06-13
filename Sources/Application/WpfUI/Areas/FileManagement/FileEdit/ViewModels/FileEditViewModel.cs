using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileEdit.ViewModels.ViewModelCommands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileEdit.ViewModels
{
    public class FileEditViewModel : ViewModelBase, IInitializableViewModel
    {
        private readonly FileEditViewModelCommands _commands;
        private readonly IFileTagDataService _fileTagDataService;
        private readonly IViewModelFactory _viewModelFactory;
        private ObservableCollection<FileTagDto> _addedFileTags;
        private CollectionViewSource _allFileTagsSource;
        private FileDto _file;
        private FileTagDisplayViewModel _fileTagDisplayViewModel;
        private string _fileTagFilter;
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
        public ICollectionView AllFileTags => _allFileTagsSource.View;

        private CollectionViewSource AllFileTagsSource
        {
            get => _allFileTagsSource;
            set
            {
                _allFileTagsSource = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AllFileTags));
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

        public string FileTagFilter
        {
            get => _fileTagFilter;
            set
            {
                _fileTagFilter = value;
                OnPropertyChanged();
                AllFileTagsSource.View.Refresh();
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
            var fileTags = await _fileTagDataService.LoadAllAsync();
            var collectionViewSource = new CollectionViewSource
            {
                Source = fileTags.OrderBy(f => f.Name).ToList()
            };

            collectionViewSource.Filter += FilterFileTag;
            AllFileTagsSource = collectionViewSource;
        }

        private void FilterFileTag(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FileTagFilter))
            {
                e.Accepted = true;
                return;
            }

            var fileTag = (FileTagDto)e.Item;
            e.Accepted = fileTag.Name.ToUpperInvariant().Contains(FileTagFilter.ToUpperInvariant());
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