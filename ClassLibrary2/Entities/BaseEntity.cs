using System.ComponentModel.DataAnnotations;

namespace CA.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

    }
}
