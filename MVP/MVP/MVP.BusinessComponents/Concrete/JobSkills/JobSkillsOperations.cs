using DataAccessSql;
using MVP.BusinessEntities;
using MVP.EntityRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.BusinessComponents
{
    public class JobSkillsOperations : IJobSkillsOperations
    {
        private IJobSkillsRepository JobSkillsRepository;

        public JobSkillsOperations(IJobSkillsRepository _JobSkillsRepository)
        {
            JobSkillsRepository = _JobSkillsRepository;
        }

        public async Task<DataSourceRequestEntities<bool>> InsertJobSkillsAsync(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            return await JobSkillsRepository.InsertJobSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertJobSkills(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            return JobSkillsRepository.InsertJobSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateJobSkillsAsync(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            return await JobSkillsRepository.UpdateJobSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateJobSkills(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            return JobSkillsRepository.UpdateJobSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteJobSkillsAsync(RequestInput<JobSkillsEntity> ObjRequestInput)
        {
            return await JobSkillsRepository.DeleteJobSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteJobSkills(RequestInput<JobSkillsEntity> ObjRequestInput)
        {
            return JobSkillsRepository.DeleteJobSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<JobSkillsEntity>>> GetJobSkillsListingAsync(RequestInput<JobSkillsGetFilterEntity> ObjRequestInput)
        {
            return await JobSkillsRepository.GetJobSkillsListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<JobSkillsEntity>> GetJobSkillsListing(RequestInput<JobSkillsGetFilterEntity> ObjRequestInput)
        {
            return JobSkillsRepository.GetJobSkillsListing(ObjRequestInput);
        }
    }
}
