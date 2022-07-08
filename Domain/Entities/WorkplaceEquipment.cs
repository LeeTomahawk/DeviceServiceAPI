namespace Domain.Entities
{
    public class WorkplaceEquipment : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid EquipmentId { get; set; }
        public Guid WorkplaceId { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Workplace Workplace { get; set; }
    }
}
