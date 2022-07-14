namespace Domain.Entities
{
    public class Task : AuditableEntity
    {
        public Guid Id { get; set; }
        public virtual Client? Client { get; set; }
        public Guid ClientId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public Guid? InvoiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public float? amount { get; set; }
        public TaskStatus TaskStatus { get; set; } = TaskStatus.RECEIVED;
        public virtual IEnumerable<TaskEmployee> Employees { get; set; }
        public virtual CompletedTask Employee { get; set; }
    }
}
