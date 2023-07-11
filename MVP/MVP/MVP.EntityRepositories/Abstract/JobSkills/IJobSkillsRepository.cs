using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    public interface IJobSkillsRepository
    {
        Task<DataSourceRequestEntities<bool>> InsertJobSkillsAsync(RequestInput<JobSkillsDtEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> InsertJobSkills(RequestInput<JobSkillsDtEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> UpdateJobSkillsAsync(RequestInput<JobSkillsDtEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> UpdateJobSkills(RequestInput<JobSkillsDtEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> DeleteJobSkillsAsync(RequestInput<JobSkillsEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> DeleteJobSkills(RequestInput<JobSkillsEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<List<JobSkillsEntity>>> GetJobSkillsListingAsync(RequestInput<JobSkillsGetFilterEntity> ObjRequestInput);

        DataSourceRequestEntities<List<JobSkillsEntity>> GetJobSkillsListing(RequestInput<JobSkillsGetFilterEntity> ObjRequestInput);
    }
}
