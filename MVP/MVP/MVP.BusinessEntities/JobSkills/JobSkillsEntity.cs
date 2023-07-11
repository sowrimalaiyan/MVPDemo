using System;
using System.Collections.Generic;
using System.Data;

namespace MVP.BusinessEntities
{
    public class JobSkillsInsertRequestEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<SkillIdEntity> Skills { get; set; }
    }

    public class JobSkillsRequestEntity : JobSkillsInsertRequestEntity
    {
        public Guid Id { get; set; }
    }

    public class JobSkillsEntity : SkillEntity
    {
        public Guid? JobSkillId { get; set; }
    }

    public class JobSkillsDtEntity : JobEntity
    {
        public DataTable SkillsDt { get; set; }
    }

    public class JobSkillsGetFilterEntity : TransactionEntity
    {

    }
}
