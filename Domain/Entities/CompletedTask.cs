namespace Domain.Entities
{
    public class CompletedTask : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public virtual Task Task { get; set; }

    }
}
