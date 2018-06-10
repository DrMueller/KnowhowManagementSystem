using System.Collections.Generic;

namespace Mmu.Kms.Domain
{
    public class File
    {
        public File(string filePath, string fileName, FileContent content, FileType fileType, IReadOnlyCollection<FileTag> tags)
        {
            FilePath = filePath;
            FileName = fileName;
            Content = content;
            FileType = fileType;
            Tags = tags;
        }

        public FileContent Content { get; }
        public string FilePath { get; }
        public string FileName { get; }
        public FileType FileType { get; }
        public IReadOnlyCollection<FileTag> Tags { get; }
    }
}