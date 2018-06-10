using AutoMapper;
using Mmu.Kms.Domain;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos.Profiles
{
    public class FileTypeDtoProfile : Profile
    {
        public FileTypeDtoProfile()
        {
            CreateMap<FileType, FileTypeDto>()
                .ForMember(d => d.Description, c => c.MapFrom(f => f.Description))
                .ForMember(d => d.Extension, c => c.MapFrom(f => f.Extension));
        }
    }
}