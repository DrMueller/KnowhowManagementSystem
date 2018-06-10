using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services;
using Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels.ViewModelCommands;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels
{
    public class FileTagEditViewModel : ViewModelBase, IInitializableViewModel
    {
        private readonly FileTagEditViewModelCommands _commands;
        private readonly IFileTagDataService _fileTagService;

        public FileTagEditViewModel(IFileTagDataService fileTagService, FileTagEditViewModelCommands commands)
        {
            _fileTagService = fileTagService;
            _commands = commands;
        }

        public ViewModelCommand Cancel => _commands.Cancel;

        public string Description
        {
            get => FileTag.Description;
            set => FileTag.Description = value;
        }

        public FileTagDto FileTag { get; private set; }

        public string Name
        {
            get => FileTag.Name;
            set => FileTag.Name = value;
        }

        public ViewModelCommand Save => _commands.Save;

        public async Task InitializeAsync()
        {
            await _commands.InitializeAsync(this);
        }

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