using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Repositories;
using Mmu.Kms.DomainServices.DataAccess.Areas.FileTagManagement.DataModels;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileTagManagement.Repositories
{
    public class FileTagRepository : RepositoryBase<FileTag, FileTagDataModel>, IFileTagRepository
    {
        private readonly IDataModelAdapter<FileTagDataModel, FileTag> _dataModelAdapter;
        private readonly IDataModelRepository<FileTagDataModel> _dataModelRepository;

        public FileTagRepository(IDataModelRepository<FileTagDataModel> dataModelRepository, IDataModelAdapter<FileTagDataModel, FileTag> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelAdapter = dataModelAdapter;
        }

        public async Task<IReadOnlyCollection<FileTag>> LoadAsyncByNames(IReadOnlyCollection<string> fileTagNames)
        {
            var dataModels = await _dataModelRepository.LoadAsync(f => fileTagNames.Contains(f.Name));
            var result = dataModels.Select(_dataModelAdapter.Adapt).ToList();
            return result;
        }

        public async Task<IReadOnlyCollection<FileTag>> LoadByIdsAsync(IReadOnlyCollection<string> ids)
        {
            var dataModels = await _dataModelRepository.LoadAsync(f => ids.Contains(f.Id));
            var result = dataModels.Select(_dataModelAdapter.Adapt).ToList();
            return result;
        }
    }
}