namespace Domain.Entities
{
    public class Workplace : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public virtual IEnumerable<WorkplaceEquipment> Equipments { get; set; }
    }
}
