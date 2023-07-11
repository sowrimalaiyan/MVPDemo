using DataAccessSql;
using MVP.BusinessEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    public class EmployeeSkillsRepository : IEmployeeSkillsRepository
    {
        public async Task<DataSourceRequestEntities<bool>> InsertEmployeeSkillsAsync(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            return await EmployeeSkillsProcedureList.InsertEmployeeSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> InsertEmployeeSkills(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            return EmployeeSkillsProcedureList.InsertEmployeeSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> UpdateEmployeeSkillsAsync(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            return await EmployeeSkillsProcedureList.UpdateEmployeeSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> UpdateEmployeeSkills(RequestInput<EmployeeSkillsDtEntity> ObjRequestInput)
        {
            return EmployeeSkillsProcedureList.UpdateEmployeeSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<bool>> DeleteEmployeeSkillsAsync(RequestInput<EmployeeSkillsEntity> ObjRequestInput)
        {
            return await EmployeeSkillsProcedureList.DeleteEmployeeSkillsAsync(ObjRequestInput).ConfigureAwait(false);
        }

        public DataSourceRequestEntities<bool> DeleteEmployeeSkills(RequestInput<EmployeeSkillsEntity> ObjRequestInput)
        {
            return EmployeeSkillsProcedureList.DeleteEmployeeSkills(ObjRequestInput);
        }

        public async Task<DataSourceRequestEntities<List<EmployeeSkillsEntity>>> GetEmployeeSkillsListingAsync(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput)
        {
            return await EmployeeSkillsProcedureList.GetEmployeeSkillsListingAsync(ObjRequestInput);
        }

        public DataSourceRequestEntities<List<EmployeeSkillsEntity>> GetEmployeeSkillsListing(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput)
        {
            return EmployeeSkillsProcedureList.GetEmployeeSkillsListing(ObjRequestInput);
        }
    }
}
