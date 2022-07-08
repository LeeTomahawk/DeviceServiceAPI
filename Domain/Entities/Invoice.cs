namespace Domain.Entities
{
    public class Invoice : AuditableEntity
    {
        public Guid Id { get; set; }
        public float TotalAmount { get; set; }
        public DateTime PaidDate { get; set; }
        public string Description { get; set; }
    }
}
