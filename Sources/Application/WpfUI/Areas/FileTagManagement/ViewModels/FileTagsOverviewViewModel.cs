using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Repositories;
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
        private readonly IFileTagRepository _fileTagRepository;
        private readonly FileTagsOverViewViewModelCommands _commands;

        public ObservableCollection<FileTag> FileTags { get; private set; }

        public FileTag SelectedFileTag { get; set; }

        public FileTagsOverviewViewModel(
            IFileTagRepository fileTagRepository,
            FileTagsOverViewViewModelCommands commands
            )
        {
            _fileTagRepository = fileTagRepository;
            _commands = commands;
        }

        public ViewModelCommand CreateFileTag => _commands.CreateFileTag;
        public ViewModelCommand DeleteFileTag => _commands.DeleteFileTag;
        public ViewModelCommand UpdateFileTag => _commands.UpdateFileTag;
        public string NavigationDescription { get; } = "Tags";
        public int NavigationSequence { get; } = 2;
        public string HeadingText { get; } = "Tags Management";

        public async Task InitializeAsync()
        {
            var tagsList = await _fileTagRepository.LoadAllAsync();
            FileTags = new ObservableCollection<FileTag>(tagsList);
        }
    }
}