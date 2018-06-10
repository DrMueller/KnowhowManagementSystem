using System.IO;
using Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Dtos;
using Mmu.Mlh.LanguageExtensions.Areas.Proxies;
using Newtonsoft.Json;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Services.Implementation
{
    public class ShadowFileService : IShadowFileService
    {
        private readonly IFileProxy _fileProxy;

        public ShadowFileService(IFileProxy fileProxy)
        {
            _fileProxy = fileProxy;
        }

        public ShadowFileDto LoadShadowFile(string filePath)
        {
            var jsonFile = Path.ChangeExtension(filePath, "json");

            if (!File.Exists(jsonFile))
            {
                return ShadowFileDto.CreateEmpty(jsonFile);
            }

            var json = _fileProxy.ReadAllText(jsonFile);
            var result = JsonConvert.DeserializeObject<ShadowFileDto>(json) ?? ShadowFileDto.CreateEmpty(filePath);
            return result;
        }

        public void SaveShadowFile(string filePath, ShadowFileDto dto)
        {
            var jsonFile = Path.ChangeExtension(filePath, "json");
            var json = JsonConvert.SerializeObject(dto);
            _fileProxy.WriteAllText(jsonFile, json);
        }

        ////private static void CreateAndHideFile(string filePath)
        ////{
        ////    File.Create(filePath).Dispose();
        ////    File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.Hidden);
        ////}
    }
}