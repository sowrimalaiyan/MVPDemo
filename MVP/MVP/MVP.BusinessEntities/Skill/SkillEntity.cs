using System;

namespace MVP.BusinessEntities
{
	public class SkillInsertRequestEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }
	}

	public class SkillRequestEntity : SkillInsertRequestEntity
	{
		public Guid Id { get; set; }
	}

	public class SkillIdEntity
	{
		public Guid Id { get; set; }
	}

	public class SkillEntity : SkillIdEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public bool IsActive { get; set; }

		public Guid CreatedBy { get; set; }

		public DateTime CreatedAt { get; set; }

		public Guid UpdatedBy { get; set; }

		public DateTime UpdatedAt { get; set; }
	}

    public class SkillGetFilterEntity : TransactionEntity
    {

    }
}
