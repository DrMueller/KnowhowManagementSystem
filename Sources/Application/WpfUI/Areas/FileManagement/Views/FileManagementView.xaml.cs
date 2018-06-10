using System;
using System.Windows;
using System.Windows.Controls;
using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Views
{
    public partial class FileManagementView : UserControl
    {
        public FileManagementView()
        {
            InitializeComponent();
        }

        private void Tv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeView = (TreeView)sender;
            if (!(treeView.SelectedItem is FileViewModel))
            {
                return;
            }

            var selectedItem = (FileViewModel) treeView.SelectedItem;
            var vm = (FileManagementViewModel)DataContext;
            vm.SelectedItemChanged(selectedItem);
        }
    }
}