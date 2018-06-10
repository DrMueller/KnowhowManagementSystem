using AutoMapper;
using Mmu.Kms.Domain;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos.Profiles
{
    public class FileSearchParametersDtoProfile : Profile
    {
        public FileSearchParametersDtoProfile()
        {
            CreateMap<FileSearchParameters, FileSearchParametersDto>()
                .ForMember(d => d.FileContent, c => c.MapFrom(f => f.FileContent))
                .ForMember(d => d.FileName, c => c.MapFrom(f => f.FileName))
                .ForMember(d => d.FileTag, c => c.MapFrom(f => f.FileTag))
                .ForMember(d => d.FileType, c => c.MapFrom(f => f.FileType))
                .ForMember(d => d.RootPath, c => c.MapFrom(f => f.RootPath));
        }
    }
}