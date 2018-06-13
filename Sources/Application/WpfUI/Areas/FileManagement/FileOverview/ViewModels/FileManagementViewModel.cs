using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels.ViewModelCommands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels
{
    public class FileManagementViewModel : ViewModelBase, IInitializableViewModel
    {
        private readonly FileManagementViewModelCommands _commands;
        private IReadOnlyCollection<FolderEntryViewModel> _folderEntries;
        private FolderEntryViewModel _selectedFile;

        public FileManagementViewModel(
            FileManagementViewModelCommands commands) => _commands = commands;

        public ViewModelCommand EditFile => _commands.EditFile;
        public ICommand EditFileCommand => _commands.EditFileCommand;

        public IReadOnlyCollection<FolderEntryViewModel> FolderEntries
        {
            get => _folderEntries;
            set
            {
                _folderEntries = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCommand OpenFile => _commands.OpenFile;

        public FolderEntryViewModel SelectedFile
        {
            get => _selectedFile;
            set
            {
                _selectedFile = value;
                OnPropertyChanged();
            }
        }

        public async Task InitializeAsync()
        {
            await _commands.InitializeAsync(this);
        }

        public void SelectedItemChanged(FolderEntryViewModel folderEntryVm)
        {
            SelectedFile = folderEntryVm;
        }
    }
}