using DataAccessSql;
using MVP.BusinessEntities;
using MVP.EntityRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.BusinessComponents
{
    public class EmployeeOperations : IEmployeeOperations
    {
        private IEmployeeRepository EmployeeRepository;

        public EmployeeOperations(IEmployeeRepository _EmployeeRepository)
        {
            EmployeeRepository = _EmployeeRepository;
        }

        public async Task<DataSourceRequestEntities<bool>> InsertEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return await EmployeeRepository.InsertEmployeeAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertEmployee(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return EmployeeRepository.InsertEmployee(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return await EmployeeRepository.UpdateEmployeeAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateEmployee(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return EmployeeRepository.UpdateEmployee(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteEmployeeAsync(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return await EmployeeRepository.DeleteEmployeeAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteEmployee(RequestInput<EmployeeEntity> ObjRequestInput)
        {
            return EmployeeRepository.DeleteEmployee(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<EmployeeEntity>>> GetEmployeeListingAsync(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            return await EmployeeRepository.GetEmployeeListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<EmployeeEntity>> GetEmployeeListing(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            return EmployeeRepository.GetEmployeeListing(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<EmployeeEntity>> GetEmployeeDetailsAsync(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            return await EmployeeRepository.GetEmployeeDetailsAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<EmployeeEntity> GetEmployeeDetails(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            return EmployeeRepository.GetEmployeeDetails(ObjRequestInput);
        }
    }
}
