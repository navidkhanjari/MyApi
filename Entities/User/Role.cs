using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
