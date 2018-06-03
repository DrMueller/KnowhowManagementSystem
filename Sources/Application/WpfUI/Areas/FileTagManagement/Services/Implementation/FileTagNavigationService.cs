using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Services;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.Services.Implementation
{
    public class FileTagNavigationService : IFileTagNavigationService
    {
        private readonly INavigationService _navigationService;
        private readonly IViewModelFactory _viewModelFactory;

        public FileTagNavigationService(
            INavigationService navigationService,
            IViewModelFactory viewModelFactory)
        {
            _navigationService = navigationService;
            _viewModelFactory = viewModelFactory;
        }

        public async Task NavigateToFileTagEditAsync(Maybe<string> id)
        {
            var viewModel = await _viewModelFactory.CreateAsync<FileTagEditViewModel>();
            await viewModel.InitializeAsync(id);

            await _navigationService.NavigateToAsync(viewModel);
        }
    }
}
