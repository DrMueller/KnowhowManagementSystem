using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels;
using Mmu.Kms.WpfUI.Areas.FileManagement.Views;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Services.Implementation
{
    public class FileEditService : IFileEditService
    {
        private readonly IViewModelFactory _viewModelFactory;

        public FileEditService(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public async Task EditFileAsync(FileDto dto)
        {
            var viewModel = await _viewModelFactory.CreateAsync<FileEditViewModel>();
            await viewModel.InitializeFileAsync(dto);
            var view = new FileEditView { DataContext = viewModel };

            view.ShowDialog();
        }
    }
}