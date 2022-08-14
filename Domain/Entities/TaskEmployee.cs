namespace Domain.Entities
{
    public class TaskEmployee : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Task Task { get; set; }
        public virtual Employee Employee { get; set; }
        public TaskDetailStatus? TaskDetailStatus { get; set; }
        public DateTime? TakeTaskDate { get; set; }
        public DateTime? DoneTaskDate { get; set; }
    }
}
