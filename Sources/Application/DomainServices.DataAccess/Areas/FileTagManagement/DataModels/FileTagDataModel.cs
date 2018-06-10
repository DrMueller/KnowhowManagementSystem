using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileTagManagement.DataModels
{
    public class FileTagDataModel : DataModelBase
    {
        public string Description { get; set; }
        public string Name { get; set; }
    }
}