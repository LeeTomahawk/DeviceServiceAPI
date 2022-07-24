namespace Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public Guid Id { get; set; }
        public virtual Identiti Identiti { get; set; }
        public Guid IdentitiId { get; set; }
        public virtual Workplace Workplace { get; set; }
        public Guid? WorkplaceId { get; set; }
        public DateTime EmploymentDate { get; set; }
        public virtual IEnumerable<TaskEmployee> Tasks { get; set; }
        public virtual IEnumerable<CompletedTask> CompletedTasks { get; set; }
    }
}