using AutoMapper;
using Mmu.Kms.Domain;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos.Profiles
{
    public class FileContentDtoProfile : Profile
    {
        public FileContentDtoProfile()
        {
            CreateMap<FileContent, FileContentDto>()
                .ForMember(d => d.Content, c => c.MapFrom(f => f.Content));
        }
    }
}