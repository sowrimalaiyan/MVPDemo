using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<DataSourceRequestEntities<bool>> InsertEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return await EmployeeProcedureList.InsertEmployeeAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertEmployee(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return EmployeeProcedureList.InsertEmployee(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return await EmployeeProcedureList.UpdateEmployeeAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateEmployee(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return EmployeeProcedureList.UpdateEmployee(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return await EmployeeProcedureList.DeleteEmployeeAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteEmployee(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return EmployeeProcedureList.DeleteEmployee(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<EmployeeEntity>>> GetEmployeeListingAsync(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            return await EmployeeProcedureList.GetEmployeeListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<EmployeeEntity>> GetEmployeeListing(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            return EmployeeProcedureList.GetEmployeeListing(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<EmployeeEntity>> GetEmployeeDetailsAsync(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            return await EmployeeProcedureList.GetEmployeeDetailsAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<EmployeeEntity> GetEmployeeDetails(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            return EmployeeProcedureList.GetEmployeeDetails(ObjRequestInput);
        }
    }
}
