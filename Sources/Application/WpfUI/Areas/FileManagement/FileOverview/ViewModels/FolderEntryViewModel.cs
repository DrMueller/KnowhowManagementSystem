using System.Collections.Generic;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels
{
    public class FolderEntryViewModel : ViewModelBase
    {
        public FolderEntryViewModel(FolderEntryViewModelType type, string name, string path, string iconPath, string tagDescription)
        {
            Type = type;
            Name = name;
            Path = path;
            IconPath = iconPath;
            TagDescription = tagDescription;
            SubEntries = new List<FolderEntryViewModel>();
        }

        public string IconPath { get; }
        public string Name { get; }
        public string Path { get; }
        public List<FolderEntryViewModel> SubEntries { get; }
        public string TagDescription { get; }
        public FolderEntryViewModelType Type { get; }
    }
}