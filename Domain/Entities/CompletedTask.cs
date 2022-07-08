﻿namespace Domain.Entities
{
    public class CompletedTask : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Task Task { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
