using System.Collections.Generic;
using System.IO;
using Mmu.Kms.DomainServices.DataAccess.Areas.Dtos;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.Services.Implementation
{
    public class ShadowFileService : IShadowFileService
    {
        public ShadowFileDto GetOrCreateShadowFile(string filePath)
        {
            var fullFile = Path.ChangeExtension(filePath, "json");

            if (!File.Exists(fullFile))
            {
                CreateAndHideFile(fullFile);
                return new ShadowFileDto
                {
                    FilePath = filePath,
                    TagNames = new List<string>()
                };
            }

            var json = File.ReadAllText(fullFile);

            // TODO: Deserialize

            return null;
        }

        private static void CreateAndHideFile(string filePath)
        {
            File.Create(filePath).Dispose();
            File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.Hidden);
        }
    }
}