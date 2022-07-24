namespace Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid Id { get;set; }
        public RoleType RoleType { get;set; }
        public virtual Identiti Identiti { get;set; }
        public Guid IdentitiId { get;set; }
        public string Email { get;set; }
        public string Password { get;set; }
    }
}
