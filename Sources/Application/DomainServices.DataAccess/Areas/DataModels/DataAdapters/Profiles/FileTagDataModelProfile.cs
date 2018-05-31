using AutoMapper;
using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.DataModels.DataAdapters.Profiles
{
    public class FileTagDataModelProfile : Profile
    {
        public FileTagDataModelProfile()
        {
            CreateMap<FileTag, FileTagDataModel>()
                .ForMember(d => d.Description, c => c.MapFrom(f => f.Description))
                .ForMember(d => d.Name, c => c.MapFrom(f => f.Name))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id));
        }
    }
}