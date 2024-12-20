using System.ComponentModel.DataAnnotations;

namespace EMSDomain
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set;}
    }
}
