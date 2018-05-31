using System.Windows.Controls;
using Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.Views
{
    /// <summary>
    /// Interaction logic for FileTagsOveriewView.xaml
    /// </summary>
    public partial class FileTagsOveriewView : UserControl, IViewMap<FileTagsOverviewViewModel>
    {
        public FileTagsOveriewView()
        {
            InitializeComponent();
        }
    }
}
