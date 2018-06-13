using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Views;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileEdit.ViewModels.ViewModelCommands
{
    public class FileEditViewModelCommands : IViewModelCommandContainer<FileEditViewModel>
    {
        private readonly IFileDataService _fileDataService;

        public FileEditViewModelCommands(IFileDataService fileDataService)
        {
            _fileDataService = fileDataService;
        }

        private FileEditViewModel _context;
        public ICommand AddFileTagCommand =>
            new RelayCommand(
                () =>
                {
                    if (_context.AddedFileTags.All(f => f.Id != _context.SelectedFileTagToAdd.Id))
                    {
                        _context.AddedFileTags.Add(_context.SelectedFileTagToAdd);
                    }
                },
                () => _context.SelectedFileTagToAdd != null);
        public ICommand CancelCommand =>
            new ParametredRelayCommand(
                obj =>
                {
                    var closable = (IClosableView)obj;
                    closable.Close();
                });
        public ParametredRelayCommand SaveCommand =>
            new ParametredRelayCommand(
                async obj =>
                {
                    _context.File.Tags = new List<FileTagDto>(_context.AddedFileTags);
                    await _fileDataService.SaveAsync(_context.File);
                    var closable = (IClosableView)obj;
                    closable.Close();
                });

        public Task InitializeAsync(FileEditViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}