namespace Mmu.Kms.Domain
{
    public class FileSearchParameters
    {
        public FileSearchParameters(string rootPath, string fileName, string fileContent, FileTag fileTag, FileType fileType)
        {
            RootPath = rootPath;
            FileName = fileName;
            FileContent = fileContent;
            FileTag = fileTag;
            FileType = fileType;
        }

        public string FileContent { get; }
        public string FileName { get; }
        public FileTag FileTag { get; }
        public FileType FileType { get; }
        public string RootPath { get; }
    }
}