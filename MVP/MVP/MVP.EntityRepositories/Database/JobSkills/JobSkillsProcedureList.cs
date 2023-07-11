using DataAccessSql;
using MVP.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class JobSkillsProcedureList
    {
        public static async Task<DataSourceRequestEntities<bool>> InsertJobSkillsAsync(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = InsertJobSkillsSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> InsertJobSkills(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = InsertJobSkillsSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> UpdateJobSkillsAsync(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = UpdateJobSkillsSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> UpdateJobSkills(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = UpdateJobSkillsSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> DeleteJobSkillsAsync(RequestInput<JobSkillsEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = DeleteJobSkillsSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> DeleteJobSkills(RequestInput<JobSkillsEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = DeleteJobSkillsSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<List<JobSkillsEntity>>> GetJobSkillsListingAsync(RequestInput<JobSkillsGetFilterEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<List<JobSkillsEntity>>> Obj = GetJobSkillsListingSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<List<JobSkillsEntity>>(new List<JobSkillsEntity>(), ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<List<JobSkillsEntity>> GetJobSkillsListing(RequestInput<JobSkillsGetFilterEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<List<JobSkillsEntity>> Obj = GetJobSkillsListingSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<List<JobSkillsEntity>>(new  List<JobSkillsEntity>(), ex.Message);
            }
        }
    }
}
