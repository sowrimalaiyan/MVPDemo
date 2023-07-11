using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.BusinessComponents
{
    public interface ISkillOperations
    {
        Task<DataSourceRequestEntities<bool>> InsertSkillAsync(RequestInput<SkillEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> InsertSkill(RequestInput<SkillEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> UpdateSkillAsync(RequestInput<SkillEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> UpdateSkill(RequestInput<SkillEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> DeleteSkillAsync(RequestInput<SkillEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> DeleteSkill(RequestInput<SkillEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<List<SkillEntity>>> GetSkillListingAsync(RequestInput<SkillGetFilterEntity> ObjRequestInput);

        DataSourceRequestEntities<List<SkillEntity>> GetSkillListing(RequestInput<SkillGetFilterEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<SkillEntity>> GetSkillDetailsAsync(RequestInput<SkillGetFilterEntity> ObjRequestInput);

        DataSourceRequestEntities<SkillEntity> GetSkillDetails(RequestInput<SkillGetFilterEntity> ObjRequestInput);
    }
}
