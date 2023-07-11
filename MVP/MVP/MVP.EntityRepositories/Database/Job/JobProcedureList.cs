using DataAccessSql;
using MVP.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class JobProcedureList
    {
        public static async Task<DataSourceRequestEntities<bool>> InsertJobAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = InsertJobSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> InsertJob(RequestInput<JobEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = InsertJobSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> UpdateJobAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = UpdateJobSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> UpdateJob(RequestInput<JobEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = UpdateJobSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> DeleteJobAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = DeleteJobSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> DeleteJob(RequestInput<JobEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = DeleteJobSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<List<JobEntity>>> GetJobListingAsync(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<List<JobEntity>>> Obj = GetJobListingSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<List<JobEntity>>(new List<JobEntity>(), ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<List<JobEntity>> GetJobListing(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<List<JobEntity>> Obj = GetJobListingSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<List<JobEntity>>(new  List<JobEntity>(), ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<JobEntity>> GetJobDetailsAsync(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<JobEntity>> Obj = GetJobDetailsSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<JobEntity>(new JobEntity(), ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<JobEntity> GetJobDetails(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<JobEntity> Obj = GetJobDetailsSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<JobEntity>(new JobEntity(), ex.Message);
            }
        }
    }
}
