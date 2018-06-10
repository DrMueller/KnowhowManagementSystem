using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.WpfUI.Areas.FileManagement.Services;
using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels.ViewModelCommands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FileManagementViewModel : ViewModelBase, IInitializableViewModel
    {
        private readonly FileManagementViewModelCommands _commands;
        private readonly IDirectoryViewModelFactory _directoryViewModelFactory;
        private IReadOnlyCollection<DirectoryViewModel> _directories;
        private DirectoryStructureDto _directoryStructure;
        private FileDto _selectedFile;

        public FileManagementViewModel(
            FileManagementViewModelCommands commands,
            IDirectoryViewModelFactory directoryViewModelFactory)
        {
            _commands = commands;
            _directoryViewModelFactory = directoryViewModelFactory;
        }

        public IReadOnlyCollection<DirectoryViewModel> Directories
        {
            get => _directories;
            set
            {
                _directories = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCommand EditFile => _commands.EditFile;

        public ViewModelCommand OpenFile => _commands.OpenFile;

        public DirectoryStructureDto DirectoryStructure
        {
            get => _directoryStructure;
            set
            {
                _directoryStructure = value;
                Directories = _directoryViewModelFactory.Create(value);
                OnPropertyChanged();
            }
        }

        public FileDto SelectedFile
        {
            get => _selectedFile;
            set
            {
                _selectedFile = value;
                OnPropertyChanged();
            }
        }

        public void SelectedItemChanged(FileViewModel fileVm)
        {
            var files = _directoryStructure.Directories.SelectMany(f => f.Files);
            SelectedFile = files.First(f => f.FileName == fileVm.FileName && f.FilePath == fileVm.DirectoryPath);
        }

        public async Task InitializeAsync()
        {
            await _commands.InitializeAsync(this);
        }
    }
}