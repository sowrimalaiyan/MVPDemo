using System;

namespace MVP.BusinessEntities
{
    public class EmployeeInsertRequestEntity
    {
        public string Name { get; set; }

        public Int64 PhoneNo { get; set; }
    }

    public class EmployeeRequestEntity : EmployeeInsertRequestEntity
    {
        public Guid Id { get; set; }
    }

    public class EmployeeEntity : EmployeeRequestEntity
    {
        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class EmployeeGetFilterEntity : TransactionEntity
    {

    }
}
