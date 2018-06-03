using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.Services;
using Mmu.Kms.WpfUI.Areas.FileTagManagement.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels.ViewModelCommands
{
    public class FileTagsOverViewViewModelCommands : IViewModelCommandContainer<FileTagsOverviewViewModel>
    {
        private readonly IFileTagDataService _fileTagService;
        private readonly IFileTagNavigationService _navigationService;

        public FileTagsOverViewViewModelCommands(
            IFileTagNavigationService navigationService,
            IFileTagDataService fileTagService
        )
        {
            _navigationService = navigationService;
            _fileTagService = fileTagService;
        }

        public ViewModelCommand CreateFileTag { get; private set; }
        public ViewModelCommand DeleteFileTag { get; private set; }
        public ViewModelCommand UpdateFileTag { get; private set; }

        public Task InitializeAsync(FileTagsOverviewViewModel context)
        {
            return Task.Run(
                () =>
                {
                    CreateFileTag = new ViewModelCommand(
                        "Create",
                        new RelayCommand(
                            async () =>
                            {
                                await _navigationService.NavigateToFileTagEditAsync(Maybe.CreateNone<string>());
                            }));

                    UpdateFileTag = new ViewModelCommand(
                        "Update",
                        new RelayCommand(
                            async () =>
                            {
                                await _navigationService.NavigateToFileTagEditAsync(
                                    Maybe.CreateSome(context.SelectedFileTag.Id));
                            },
                            () => context.SelectedFileTag != null));

                    DeleteFileTag = new ViewModelCommand(
                        "Delete",
                        new RelayCommand(
                            async () =>
                            {
                                await _fileTagService.DeleteAsync(context.SelectedFileTag.Id);
                                context.FileTags.Remove(context.SelectedFileTag);
                                context.SelectedFileTag = null;
                            },
                            () => context.SelectedFileTag != null));
                });
        }
    }
}