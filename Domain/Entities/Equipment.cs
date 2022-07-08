namespace Domain.Entities
{
    public class Equipment : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public virtual IEnumerable<WorkplaceEquipment> Workplaces { get; set; }
    }
}
