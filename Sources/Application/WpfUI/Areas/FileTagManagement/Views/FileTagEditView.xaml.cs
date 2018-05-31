using System.Windows.Controls;
using Mmu.Kms.WpfUI.Areas.FileTagManagement.ViewModels;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.Views
{
    /// <summary>
    /// Interaction logic for FileTagEditView.xaml
    /// </summary>
    public partial class FileTagEditView : UserControl, IViewMap<FileTagEditViewModel>
    {
        public FileTagEditView()
        {
            InitializeComponent();
        }
    }
}
