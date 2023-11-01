using IPMEDTH.Domain.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPMEDTH.Domain.Core.Entities
{
    [Table("scores")]
    public class ScoreEntity : Entity
    {
        [Column("score")]
        [Required]
        public int Score { get; set; }
    }
}
