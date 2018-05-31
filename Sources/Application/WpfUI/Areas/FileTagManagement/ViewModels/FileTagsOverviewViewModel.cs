using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels
{
    public class FileTagsOverviewViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading
    {
        public string NavigationDescription { get; } = "Tags";
        public int NavigationSequence { get; } = 2;
        public string HeadingText { get; } = "Tags Management";
    }
}