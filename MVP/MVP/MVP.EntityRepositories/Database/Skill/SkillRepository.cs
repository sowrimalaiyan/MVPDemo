using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    public class SkillRepository : ISkillRepository
    {
        public async Task<DataSourceRequestEntities<bool>> InsertSkillAsync(RequestInput<SkillEntity> ObjRequestInput)
        {
            return await SkillProcedureList.InsertSkillAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertSkill(RequestInput<SkillEntity> ObjRequestInput)
        {
            return SkillProcedureList.InsertSkill(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateSkillAsync(RequestInput<SkillEntity> ObjRequestInput)
        {
            return await SkillProcedureList.UpdateSkillAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateSkill(RequestInput<SkillEntity> ObjRequestInput)
        {
            return SkillProcedureList.UpdateSkill(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteSkillAsync(RequestInput<SkillEntity> ObjRequestInput)
        {
            return await SkillProcedureList.DeleteSkillAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteSkill(RequestInput<SkillEntity> ObjRequestInput)
        {
            return SkillProcedureList.DeleteSkill(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<SkillEntity>>> GetSkillListingAsync(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            return await SkillProcedureList.GetSkillListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<SkillEntity>> GetSkillListing(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            return SkillProcedureList.GetSkillListing(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<SkillEntity>> GetSkillDetailsAsync(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            return await SkillProcedureList.GetSkillDetailsAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<SkillEntity> GetSkillDetails(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            return SkillProcedureList.GetSkillDetails(ObjRequestInput);
        }
    }
}
