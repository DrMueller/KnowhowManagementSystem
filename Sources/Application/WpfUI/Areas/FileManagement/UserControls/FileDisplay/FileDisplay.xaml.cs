using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Mmu.Kms.Domain;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.UserControls.FileDisplay
{
    public partial class FileDisplay : UserControl
    {
        public static readonly DependencyProperty DirectoryStructureProperty =
            DependencyProperty.Register(
                nameof(DirectoryStructure),
                typeof(DirectoryStructure),
                typeof(FileDisplay),
                new PropertyMetadata(DirectoryStructureChanged));

        public FileDisplay()
        {
            InitializeComponent();
        }

        public DirectoryStructure DirectoryStructure
        {
            get => (DirectoryStructure)GetValue(DirectoryStructureProperty);
            set => SetValue(DirectoryStructureProperty, value);
        }

        public IReadOnlyCollection<TreeViewItem> TreeViewItems { get; private set; }

        private static void DirectoryStructureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fd = (FileDisplay)d;
            var directoryStructure = (DirectoryStructure)e.NewValue;
            fd.CreateTreeViewItems(directoryStructure);
        }

        private void CreateTreeViewItems(DirectoryStructure directoryStructure)
        {
            var root = new TreeViewItem();
            foreach (var directory in directoryStructure.Directories)
            {
                CreateTreeViewItemsRecursive(directory, root);
            }

            TreeViewItems = root.Items.Cast<TreeViewItem>().ToList();
        }

        private void CreateTreeViewItemsRecursive(Directory directory, ItemsControl parentTreeViewItem)
        {
            var directoryItem = CreateFromDirectory(directory);
            parentTreeViewItem.Items.Add(directoryItem);

            var fileItems = directory.Files.Select(CreateFromFile);
            foreach (var fi in fileItems)
            {
                directoryItem.Items.Add(fi);
            }

            foreach (var subDirectory in directory.SubDirectories)
            {
                CreateTreeViewItemsRecursive(subDirectory, directoryItem);
            }
        }

        private TreeViewItem CreateFromDirectory(Directory directory)
        {
            var result = CreateTreeViewItemTemplate();
            result.Header = new FileDisplayItemViewModel(
                directory.DirectoryName,
                "/Mmu.Kms.WpfUI;component/Infrastructure/Assets/FA_Arrow.png",
                new List<string>());

            return result;
        }

        private TreeViewItem CreateFromFile(File file)
        {
            var result = CreateTreeViewItemTemplate();
            result.Header = new FileDisplayItemViewModel(
                file.FileName,
                "/Mmu.Kms.WpfUI;component/Infrastructure/Assets/FA_Cog_Green.png",
                file.Tags.Select(f => f.Name).ToList());

            return result;
        }

        private TreeViewItem CreateTreeViewItemTemplate()
        {
            var dataTemplate = FindResource("DisplayItemTemplate") as DataTemplate;

            return new TreeViewItem
            {
                FontWeight = FontWeights.Normal,
                HeaderTemplate = dataTemplate
            };
        }
    }
}