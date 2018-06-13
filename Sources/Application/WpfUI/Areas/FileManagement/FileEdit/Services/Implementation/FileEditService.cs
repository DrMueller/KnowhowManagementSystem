using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Services;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileEdit.ViewModels;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileEdit.Views;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileEdit.Services.Implementation
{
    public class FileEditService : IFileEditService
    {
        private readonly IFileService _fileService;
        private readonly IViewModelFactory _viewModelFactory;

        public FileEditService(IViewModelFactory viewModelFactory, IFileService fileService)
        {
            _viewModelFactory = viewModelFactory;
            _fileService = fileService;
        }

        public async Task EditFileAsync(string filePath)
        {
            var viewModel = await _viewModelFactory.CreateAsync<FileEditViewModel>();
            var fileDto = await _fileService.LoadFileAsync(filePath);

            await viewModel.InitializeFileAsync(fileDto);
            var view = new FileEditView { DataContext = viewModel };

            view.ShowDialog();
        }
    }
}