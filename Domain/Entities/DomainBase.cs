namespace Domain.Entities
{
    public class DomainBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
