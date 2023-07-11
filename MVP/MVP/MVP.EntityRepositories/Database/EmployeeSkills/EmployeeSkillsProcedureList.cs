using DataAccessSql;
using MVP.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class EmployeeSkillsProcedureList
    {
        public static async Task<DataSourceRequestEntities<bool>> InsertEmployeeSkillsAsync(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = InsertEmployeeSkillsSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> InsertEmployeeSkills(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = InsertEmployeeSkillsSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> UpdateEmployeeSkillsAsync(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = UpdateEmployeeSkillsSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> UpdateEmployeeSkills(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = UpdateEmployeeSkillsSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> DeleteEmployeeSkillsAsync(RequestInput<EmployeeSkillsEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = DeleteEmployeeSkillsSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> DeleteEmployeeSkills(RequestInput<EmployeeSkillsEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = DeleteEmployeeSkillsSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<List<EmployeeSkillsEntity>>> GetEmployeeSkillsListingAsync(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<List<EmployeeSkillsEntity>>> Obj = GetEmployeeSkillsListingSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<List<EmployeeSkillsEntity>>(new List<EmployeeSkillsEntity>(), ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<List<EmployeeSkillsEntity>> GetEmployeeSkillsListing(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<List<EmployeeSkillsEntity>> Obj = GetEmployeeSkillsListingSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<List<EmployeeSkillsEntity>>(new  List<EmployeeSkillsEntity>(), ex.Message);
            }
        }
    }
}
