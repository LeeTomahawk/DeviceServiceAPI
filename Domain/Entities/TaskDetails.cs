namespace Domain.Entities
{
    public class TaskDetails : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public TaskDetailStatus TaskDetailStatus { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual IEnumerable<Task> Tasks { get; set; }
    }
}
