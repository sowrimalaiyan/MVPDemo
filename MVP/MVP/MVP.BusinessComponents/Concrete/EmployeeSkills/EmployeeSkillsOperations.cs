using DataAccessSql;
using MVP.BusinessEntities;
using MVP.EntityRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.BusinessComponents
{
    public class EmployeeSkillsOperations : IEmployeeSkillsOperations
    {
        private IEmployeeSkillsRepository EmployeeSkillsRepository;

        public EmployeeSkillsOperations(IEmployeeSkillsRepository _EmployeeSkillsRepository)
        {
            EmployeeSkillsRepository = _EmployeeSkillsRepository;
        }

        public async Task<DataSourceRequestEntities<bool>> InsertEmployeeSkillsAsync(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            return await EmployeeSkillsRepository.InsertEmployeeSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertEmployeeSkills(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            return EmployeeSkillsRepository.InsertEmployeeSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateEmployeeSkillsAsync(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            return await EmployeeSkillsRepository.UpdateEmployeeSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateEmployeeSkills(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            return EmployeeSkillsRepository.UpdateEmployeeSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteEmployeeSkillsAsync(RequestInput<EmployeeSkillsEntity> ObjRequestInput)
        {
            return await EmployeeSkillsRepository.DeleteEmployeeSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteEmployeeSkills(RequestInput<EmployeeSkillsEntity> ObjRequestInput)
        {
            return EmployeeSkillsRepository.DeleteEmployeeSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<EmployeeSkillsEntity>>> GetEmployeeSkillsListingAsync(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput)
        {
            return await EmployeeSkillsRepository.GetEmployeeSkillsListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<EmployeeSkillsEntity>> GetEmployeeSkillsListing(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput)
        {
            return EmployeeSkillsRepository.GetEmployeeSkillsListing(ObjRequestInput);
        }
    }
}
