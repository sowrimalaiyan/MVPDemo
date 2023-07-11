using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    public class JobSkillsRepository : IJobSkillsRepository
    {
        public async Task<DataSourceRequestEntities<bool>> InsertJobSkillsAsync(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            return await JobSkillsProcedureList.InsertJobSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertJobSkills(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            return JobSkillsProcedureList.InsertJobSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateJobSkillsAsync(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            return await JobSkillsProcedureList.UpdateJobSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateJobSkills(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            return JobSkillsProcedureList.UpdateJobSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteJobSkillsAsync(RequestInput<JobSkillsEntity> ObjRequestInput)
        {
            return await JobSkillsProcedureList.DeleteJobSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteJobSkills(RequestInput<JobSkillsEntity> ObjRequestInput)
        {
            return JobSkillsProcedureList.DeleteJobSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<JobSkillsEntity>>> GetJobSkillsListingAsync(RequestInput<JobSkillsGetFilterEntity> ObjRequestInput)
        {
            return await JobSkillsProcedureList.GetJobSkillsListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<JobSkillsEntity>> GetJobSkillsListing(RequestInput<JobSkillsGetFilterEntity> ObjRequestInput)
        {
            return JobSkillsProcedureList.GetJobSkillsListing(ObjRequestInput);
        }
    }
}
