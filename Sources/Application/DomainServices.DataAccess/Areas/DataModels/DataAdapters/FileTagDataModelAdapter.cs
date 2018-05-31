using AutoMapper;
using Mmu.Kms.Domain;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.DataModels.DataAdapters
{
    public class FileTagDataModelAdapter : IDataModelAdapter<FileTagDataModel, FileTag>
    {
        private readonly IMapper _mapper;

        public FileTagDataModelAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public FileTag Adapt(FileTagDataModel dataModel) => new FileTag(dataModel.Id, dataModel.Name, dataModel.Description);

        public FileTagDataModel Adapt(FileTag aggregateRoot) => _mapper.Map<FileTagDataModel>(aggregateRoot);
    }
}