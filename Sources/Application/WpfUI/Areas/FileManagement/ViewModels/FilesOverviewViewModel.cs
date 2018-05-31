using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Repositories;
using Mmu.Kms.DomainServices.Areas.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FilesOverviewViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading
    {
        private readonly IDirectoryStructureService _directoryStructureService;
        private readonly IFileRepository _fileRepository;

        public FilesOverviewViewModel(IDirectoryStructureService directoryStructureService)
        {
            _directoryStructureService = directoryStructureService;
        }

        public DirectoryStructure DirectoryStructure { get; private set; }
        public string NavigationDescription { get; } = "Files";
        public int NavigationSequence { get; } = 1;
        public string HeadingText { get; } = "Files Overview";

        public async void SearchRequested(FileSearchParameters searchFileParameters)
        {
            DirectoryStructure = await _directoryStructureService.SearchFilesAsync(searchFileParameters);
        }
    }
}