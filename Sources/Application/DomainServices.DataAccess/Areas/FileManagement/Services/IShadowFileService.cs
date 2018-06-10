using Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Dtos;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Services
{
    public interface IShadowFileService
    {
        ShadowFileDto LoadShadowFile(string filePath);

        void SaveShadowFile(string filePath, ShadowFileDto dto);
    }
}