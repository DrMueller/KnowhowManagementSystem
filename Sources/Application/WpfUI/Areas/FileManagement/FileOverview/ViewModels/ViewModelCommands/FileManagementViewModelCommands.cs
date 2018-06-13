using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileEdit.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels.ViewModelCommands
{
    public class FileManagementViewModelCommands : IViewModelCommandContainer<FileManagementViewModel>
    {
        private readonly IFileEditService _fileEditService;
        private FileManagementViewModel _context;

        public FileManagementViewModelCommands(IFileEditService fileEditService) => _fileEditService = fileEditService;

        public ViewModelCommand EditFile
            => new ViewModelCommand(
                "Edit File",
                EditFileCommand);

        public ICommand EditFileCommand
            => new RelayCommand(
                async () =>
                {
                    await _fileEditService.EditFileAsync(_context.SelectedFile.Path);
                },
                () => _context.SelectedFile != null);

        public ViewModelCommand OpenFile
            => new ViewModelCommand(
                "Open File",
                new RelayCommand(
                    () =>
                    {
                        Process.Start(_context.SelectedFile.Path);
                    },
                    () => _context.SelectedFile != null));

        public Task InitializeAsync(FileManagementViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}