using System.Collections.Generic;

namespace Mmu.Kms.Domain
{
    public class File
    {
        public File(string directoryPath, string fileName, FileContent content, FileType fileType, IReadOnlyCollection<FileTag> tags)
        {
            DirectoryPath = directoryPath;
            FileName = fileName;
            Content = content;
            FileType = fileType;
            Tags = tags;
        }

        public FileContent Content { get; }
        public string DirectoryPath { get; }
        public string FileName { get; }
        public FileType FileType { get; }
        public IReadOnlyCollection<FileTag> Tags { get; }
    }
}