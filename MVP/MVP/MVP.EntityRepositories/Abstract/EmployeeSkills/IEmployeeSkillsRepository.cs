using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    public interface IEmployeeSkillsRepository
    {
        Task<DataSourceRequestEntities<bool>> InsertEmployeeSkillsAsync(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> InsertEmployeeSkills(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> UpdateEmployeeSkillsAsync(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> UpdateEmployeeSkills(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<bool>> DeleteEmployeeSkillsAsync(RequestInput<EmployeeSkillsEntity> ObjRequestInput);

        DataSourceRequestEntities<bool> DeleteEmployeeSkills(RequestInput<EmployeeSkillsEntity> ObjRequestInput);

        Task<DataSourceRequestEntities<List<EmployeeSkillsEntity>>> GetEmployeeSkillsListingAsync(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput);

        DataSourceRequestEntities<List<EmployeeSkillsEntity>> GetEmployeeSkillsListing(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput);
    }
}
