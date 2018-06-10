using AutoMapper;
using Mmu.Kms.Domain;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos.Profiles
{
    public class FileDtoProfile : Profile
    {
        public FileDtoProfile()
        {
            CreateMap<File, FileDto>()
                .ForMember(d => d.Content, c => c.MapFrom(f => f.Content))
                .ForMember(d => d.FilePath, c => c.MapFrom(f => f.FilePath))
                .ForMember(d => d.FileName, c => c.MapFrom(f => f.FileName))
                .ForMember(d => d.FileType, c => c.MapFrom(f => f.FileType))
                .ForMember(d => d.Tags, c => c.MapFrom(f => f.Tags));
        }
    }
}