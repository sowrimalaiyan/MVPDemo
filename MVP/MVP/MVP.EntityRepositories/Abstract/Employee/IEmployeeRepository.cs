using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    public interface IEmployeeRepository
    {
        Task<DataSourceRequestEntities<bool>> InsertEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> InsertEmployee(RequestInput<EmployeeEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> UpdateEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> UpdateEmployee(RequestInput<EmployeeEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> DeleteEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> DeleteEmployee(RequestInput<EmployeeEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<List<EmployeeEntity>>> GetEmployeeListingAsync(RequestInput<EmployeeGetFilterEntity> ObjRequestInput);

        DataSourceRequestEntities<List<EmployeeEntity>> GetEmployeeListing(RequestInput<EmployeeGetFilterEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<EmployeeEntity>> GetEmployeeDetailsAsync(RequestInput<EmployeeGetFilterEntity> ObjRequestInput);

        DataSourceRequestEntities<EmployeeEntity> GetEmployeeDetails(RequestInput<EmployeeGetFilterEntity> ObjRequestInput);
    }
}
