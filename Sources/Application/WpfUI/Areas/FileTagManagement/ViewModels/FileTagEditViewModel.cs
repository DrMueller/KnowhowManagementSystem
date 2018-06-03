using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.Dtos;
using Mmu.Kms.Application.Areas.Domain.Services;
using Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels.ViewModelCommands;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels
{
    public class FileTagEditViewModel : ViewModelBase
    {
        private readonly IFileTagDataService _fileTagService;
        private readonly FileTagEditViewModelCommands _commands;

        public FileTagEditViewModel(IFileTagDataService fileTagService, FileTagEditViewModelCommands commands)
        {
            _fileTagService = fileTagService;
            _commands = commands;
        }

        public FileTagDto FileTag { get; private set; }

        public async Task InitializeAsync(Maybe<string> idMaybe)
        {
            var id = idMaybe.Reduce((string)null);

            if (!string.IsNullOrEmpty(id))
            {
                FileTag = await _fileTagService.LoadAsync(id);
            }
            else
            {
                FileTag = new FileTagDto();
            }
        }
    }
}