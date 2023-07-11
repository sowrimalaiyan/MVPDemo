using DataAccessSql;
using MVP.BusinessEntities;
using MVP.EntityRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.BusinessComponents
{
    public class SkillOperations : ISkillOperations
    {
        private ISkillRepository SkillRepository;

        public SkillOperations(ISkillRepository _SkillRepository)
        {
            SkillRepository = _SkillRepository;
        }

        public async Task<DataSourceRequestEntities<bool>> InsertSkillAsync(RequestInput<SkillEntity> ObjRequestInput)
        {
            return await SkillRepository.InsertSkillAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertSkill(RequestInput<SkillEntity> ObjRequestInput)
        {
            return SkillRepository.InsertSkill(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateSkillAsync(RequestInput<SkillEntity> ObjRequestInput)
        {
            return await SkillRepository.UpdateSkillAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateSkill(RequestInput<SkillEntity> ObjRequestInput)
        {
            return SkillRepository.UpdateSkill(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteSkillAsync(RequestInput<SkillEntity> ObjRequestInput)
        {
            return await SkillRepository.DeleteSkillAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteSkill(RequestInput<SkillEntity> ObjRequestInput)
        {
            return SkillRepository.DeleteSkill(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<SkillEntity>>> GetSkillListingAsync(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            return await SkillRepository.GetSkillListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<SkillEntity>> GetSkillListing(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            return SkillRepository.GetSkillListing(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<SkillEntity>> GetSkillDetailsAsync(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            return await SkillRepository.GetSkillDetailsAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<SkillEntity> GetSkillDetails(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            return SkillRepository.GetSkillDetails(ObjRequestInput);
        }
    }
}
