using System;
using System.Collections.Generic;
using System.Data;

namespace MVP.BusinessEntities
{
    public class EmployeeSkillsInsertRequestEntity
    {
        public string Name { get; set; }

        public Int64 PhoneNo { get; set; }

        public List<SkillIdEntity> Skills { get; set; }
    }

    public class EmployeeSkillsRequestEntity : EmployeeSkillsInsertRequestEntity
    {
        public Guid Id { get; set; }
    }

    public class EmployeeSkillsEntity : SkillEntity
    {
        public Guid? EmployeeSkillId { get; set; }
    }

    public class EmployeeSkillsDtEntity : EmployeeEntity
    {
        public DataTable SkillsDt { get; set; }
    }

    public class EmployeeSkillsGetFilterEntity : TransactionEntity
    {

    }
}
