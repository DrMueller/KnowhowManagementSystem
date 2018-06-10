using System.Diagnostics;
using System.Threading.Tasks;
using Mmu.Kms.WpfUI.Areas.FileManagement.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels.ViewModelCommands
{
    public class FileManagementViewModelCommands : IViewModelCommandContainer<FileManagementViewModel>
    {
        private readonly IFileEditService _fileEditService;
        private FileManagementViewModel _context;

        public FileManagementViewModelCommands(IFileEditService fileEditService)
        {
            _fileEditService = fileEditService;
        }

        public ViewModelCommand EditFile
        {
            get
            {
                return new ViewModelCommand(
                    "Edit File",
                    new RelayCommand(
                        async () =>
                        {
                            await _fileEditService.EditFileAsync(_context.SelectedFile);
                        },
                        () => _context.SelectedFile != null));
            }
        }

        public ViewModelCommand OpenFile
        {
            get
            {
                return new ViewModelCommand(
                    "Open File",
                    new RelayCommand(
                        () =>
                        {
                            Process.Start(_context.SelectedFile.FilePath);
                        },
                        () => _context.SelectedFile != null));
            }
        }

        public Task InitializeAsync(FileManagementViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}