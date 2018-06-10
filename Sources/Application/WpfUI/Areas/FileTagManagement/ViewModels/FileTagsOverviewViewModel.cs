using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services;
using Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels.ViewModelCommands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels
{
    public class FileTagsOverviewViewModel : ViewModelBase,
        IMainNavigationViewModel,
        IViewModelWithHeading,
        IInitializableViewModel
    {
        private readonly FileTagsOverViewViewModelCommands _commands;
        private readonly IFileTagDataService _fileTagDataService;

        public FileTagsOverviewViewModel(
            IFileTagDataService fileTagDataService,
            FileTagsOverViewViewModelCommands commands
        )
        {
            _fileTagDataService = fileTagDataService;
            _commands = commands;
        }

        public ViewModelCommand CreateFileTag => _commands.CreateFileTag;
        public ViewModelCommand DeleteFileTag => _commands.DeleteFileTag;
        public ObservableCollection<FileTagDto> FileTags { get; private set; }
        public FileTagDto SelectedFileTag { get; set; }
        public ViewModelCommand UpdateFileTag => _commands.UpdateFileTag;

        public async Task InitializeAsync()
        {
            await _commands.InitializeAsync(this);
            var tagsList = await _fileTagDataService.LoadAllAsync();
            FileTags = new ObservableCollection<FileTagDto>(tagsList);
        }

        public string NavigationDescription { get; } = "Tags";
        public int NavigationSequence { get; } = 2;
        public string HeadingText { get; } = "Tags Management";
    }
}