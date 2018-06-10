using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Services;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels.ViewModelCommands
{
    public class FileTagEditViewModelCommands : IViewModelCommandContainer<FileTagEditViewModel>
    {
        private readonly IFileTagDataService _fileTagDataService;
        private readonly INavigationService _navigationservice;

        public FileTagEditViewModelCommands(
            IFileTagDataService fileTagDataService,
            INavigationService navigationservice)
        {
            _fileTagDataService = fileTagDataService;
            _navigationservice = navigationservice;
        }

        public ViewModelCommand Cancel { get; private set; }
        public ViewModelCommand Save { get; private set; }

        public Task InitializeAsync(FileTagEditViewModel context)
        {
            return Task.Run(
                () =>
                {
                    Save = new ViewModelCommand(
                        "Save",
                        new RelayCommand(
                            async () =>
                            {
                                await _fileTagDataService.SaveAsync(context.FileTag);
                                await _navigationservice.NavigateToAsync<FileTagsOverviewViewModel>();
                            }));

                    Cancel = new ViewModelCommand(
                        "Cancel",
                        new RelayCommand(
                            async () =>
                            {
                                await _navigationservice.NavigateToAsync<FileTagsOverviewViewModel>();
                            }));
                });
        }
    }
}