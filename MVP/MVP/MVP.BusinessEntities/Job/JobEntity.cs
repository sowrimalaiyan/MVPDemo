using System;

namespace MVP.BusinessEntities
{
    public class JobInsertRequestEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class JobRequestEntity : JobInsertRequestEntity
    {
        public Guid Id { get; set; }
    }

    public class JobDeleteInputEntity
    {
        public Guid Id { get; set; }
    }

    public class JobEntity
    {
        public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public bool IsActive { get; set; }

		public Guid CreatedBy { get; set; }

		public DateTime CreatedAt { get; set; }

		public Guid UpdatedBy { get; set; }

		public DateTime UpdatedAt { get; set; }
	}

    public class JobGetFilterEntity : TransactionEntity
    {

    }
}
