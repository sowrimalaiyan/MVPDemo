using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    public interface IJobRepository
    {
        Task<DataSourceRequestEntities<bool>> InsertJobAsync(RequestInput<JobEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> InsertJob(RequestInput<JobEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> UpdateJobAsync(RequestInput<JobEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> UpdateJob(RequestInput<JobEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> DeleteJobAsync(RequestInput<JobEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> DeleteJob(RequestInput<JobEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<List<JobEntity>>> GetJobListingAsync(RequestInput<JobGetFilterEntity> ObjRequestInput);

        DataSourceRequestEntities<List<JobEntity>> GetJobListing(RequestInput<JobGetFilterEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<JobEntity>> GetJobDetailsAsync(RequestInput<JobGetFilterEntity> ObjRequestInput);

        DataSourceRequestEntities<JobEntity> GetJobDetails(RequestInput<JobGetFilterEntity> ObjRequestInput);
    }
}
