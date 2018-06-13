using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Models;
using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Views
{
    public partial class FileManagementView : UserControl
    {
        public FileManagementView()
        {
            InitializeComponent();
        }

        private void Tv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var treeView = (TreeView)sender;
            var selectedItem = (FolderEntryViewModel)treeView.SelectedItem;

            if (selectedItem.Type != FolderEntryViewModelType.File)
            {
                return;
            }

            var vm = (FileManagementViewModel)DataContext;

            if (vm.EditFileCommand.CanExecute(null))
            {
                vm.EditFileCommand.Execute(null);
            }
        }

        private void Tv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeView = (TreeView)sender;
            var selectedItem = (FolderEntryViewModel)treeView.SelectedItem;

            if (selectedItem.Type != FolderEntryViewModelType.File)
            {
                return;
            }

            var vm = (FileManagementViewModel)DataContext;
            vm.SelectedItemChanged(selectedItem);
        }
    }
}