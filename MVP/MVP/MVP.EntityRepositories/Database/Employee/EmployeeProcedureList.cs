using DataAccessSql;
using MVP.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class EmployeeProcedureList
    {
        public static async Task<DataSourceRequestEntities<bool>> InsertEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = InsertEmployeeSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> InsertEmployee(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = InsertEmployeeSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> UpdateEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = UpdateEmployeeSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> UpdateEmployee(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = UpdateEmployeeSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> DeleteEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = DeleteEmployeeSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> DeleteEmployee(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = DeleteEmployeeSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<List<EmployeeEntity>>> GetEmployeeListingAsync(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<List<EmployeeEntity>>> Obj = GetEmployeeListingSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<List<EmployeeEntity>>(new List<EmployeeEntity>(), ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<List<EmployeeEntity>> GetEmployeeListing(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<List<EmployeeEntity>> Obj = GetEmployeeListingSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<List<EmployeeEntity>>(new  List<EmployeeEntity>(), ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<EmployeeEntity>> GetEmployeeDetailsAsync(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<EmployeeEntity>> Obj = GetEmployeeDetailsSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<EmployeeEntity>(new EmployeeEntity(), ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<EmployeeEntity> GetEmployeeDetails(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<EmployeeEntity> Obj = GetEmployeeDetailsSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<EmployeeEntity>(new EmployeeEntity(), ex.Message);
            }
        }
    }
}
