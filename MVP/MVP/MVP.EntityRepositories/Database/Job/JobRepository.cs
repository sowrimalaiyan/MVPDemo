using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    public class JobRepository : IJobRepository
    {
        public async Task<DataSourceRequestEntities<bool>> InsertJobAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            return await JobProcedureList.InsertJobAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertJob(RequestInput<JobEntity> ObjRequestInput)
        {
            return JobProcedureList.InsertJob(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateJobAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            return await JobProcedureList.UpdateJobAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateJob(RequestInput<JobEntity> ObjRequestInput)
        {
            return JobProcedureList.UpdateJob(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteJobAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            return await JobProcedureList.DeleteJobAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteJob(RequestInput<JobEntity> ObjRequestInput)
        {
            return JobProcedureList.DeleteJob(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<JobEntity>>> GetJobListingAsync(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            return await JobProcedureList.GetJobListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<JobEntity>> GetJobListing(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            return JobProcedureList.GetJobListing(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<JobEntity>> GetJobDetailsAsync(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            return await JobProcedureList.GetJobDetailsAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<JobEntity> GetJobDetails(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            return JobProcedureList.GetJobDetails(ObjRequestInput);
        }
    }
}
