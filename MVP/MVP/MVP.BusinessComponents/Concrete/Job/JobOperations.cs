using DataAccessSql;
using MVP.BusinessEntities;
using MVP.EntityRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.BusinessComponents
{
    public class JobOperations : IJobOperations
    {
        private IJobRepository JobRepository;

        public JobOperations(IJobRepository _JobRepository)
        {
            JobRepository = _JobRepository;
        }

        public async Task<DataSourceRequestEntities<bool>> InsertJobAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            return await JobRepository.InsertJobAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertJob(RequestInput<JobEntity> ObjRequestInput)
        {
            return JobRepository.InsertJob(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateJobAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            return await JobRepository.UpdateJobAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateJob(RequestInput<JobEntity> ObjRequestInput)
        {
            return JobRepository.UpdateJob(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteJobAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            return await JobRepository.DeleteJobAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteJob(RequestInput<JobEntity> ObjRequestInput)
        {
            return JobRepository.DeleteJob(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<JobEntity>>> GetJobListingAsync(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            return await JobRepository.GetJobListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<JobEntity>> GetJobListing(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            return JobRepository.GetJobListing(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<JobEntity>> GetJobDetailsAsync(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            return await JobRepository.GetJobDetailsAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<JobEntity> GetJobDetails(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            return JobRepository.GetJobDetails(ObjRequestInput);
        }
    }
}
