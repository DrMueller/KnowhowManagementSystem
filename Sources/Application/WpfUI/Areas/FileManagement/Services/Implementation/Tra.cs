//using System.Collections.Generic;
//using System.Linq;
//using System.Windows;
//using System.Windows.Controls;
//using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
//using Mmu.Kms.WpfUI.Areas.FileManagement.UserControls.FileDisplay;
//using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels;

//namespace Mmu.Kms.WpfUI.Areas.FileManagement.Services.Implementation
//{
//    public class TreeViewItemFactory : ITreeViewItemFactory
//    {
//        public IReadOnlyCollection<TreeViewItem> Create(DirectoryStructureDto directoryStructure)
//        {
//            var root = new TreeViewItem();
//            foreach (var directory in directoryStructure.Directories)
//            {
//                CreateTreeViewItemsRecursive(directory, root);
//            }

//            var result = root.Items.Cast<TreeViewItem>().ToList();
//            return result;
//        }

//        private void CreateTreeViewItemsRecursive(DirectoryDto directory, ItemsControl parentTreeViewItem)
//        {
//            var directoryItem = CreateFromDirectory(directory);
//            parentTreeViewItem.Items.Add(directoryItem);

//            var fileItems = directory.Files.Select(CreateFromFile);
//            foreach (var fi in fileItems)
//            {
//                directoryItem.Items.Add(fi);
//            }

//            foreach (var subDirectory in directory.SubDirectories)
//            {
//                CreateTreeViewItemsRecursive(subDirectory, directoryItem);
//            }
//        }

//        private TreeViewItem CreateFromDirectory(DirectoryDto directory)
//        {
//            var result = CreateTreeViewItemTemplate();
//            result.Header = new FileDisplayItemViewModel(
//                directory.DirectoryName,
//                "/Mmu.Kms.WpfUI;component/Infrastructure/Assets/FA_Arrow.png",
//                new List<string>());

//            return result;
//        }

//        private TreeViewItem CreateFromFile(FileDto file)
//        {
//            var result = CreateTreeViewItemTemplate();
//            result.Header = new FileDisplayItemViewModel(
//                file.FileName,
//                "/Mmu.Kms.WpfUI;component/Infrastructure/Assets/FA_Cog_Green.png",
//                file.Tags.Select(f => f.Name).ToList());

//            return result;
//        }

//        private TreeViewItem CreateTreeViewItemTemplate() => new TreeViewItem
//        {
//            FontWeight = FontWeights.Normal

//            //HeaderTemplate = dataTemplate
//        };
//    }
//}