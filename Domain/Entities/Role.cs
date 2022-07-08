namespace Domain.Entities
{
    public class Role : AuditableEntity
    {
        public Guid Id { get; set; }
        public RoleType RoleType { get; set; }
    }
}
