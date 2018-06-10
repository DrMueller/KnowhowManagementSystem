using System.Windows.Input;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FileTagViewModel : ViewModelBase
    {
        public FileTagViewModel(string id, string name, ICommand removeFileTagCommand)
        {
            Id = id;
            Name = name;
            RemoveFileTagCommand = removeFileTagCommand;
        }

        public string Id { get; }
        public string Name { get; }
        public ICommand RemoveFileTagCommand { get; }
    }
}