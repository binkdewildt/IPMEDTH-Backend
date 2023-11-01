using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace IPMEDTH.Domain.Core.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        [Key]
        [Column("id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "An ID is required")]
        public virtual TId Id { get; set; } = default!;



        private int? _requestedHashCode;
        public bool IsTransient()
        {
            return Id == null || Id.Equals(default(TId));
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not EntityBase<TId>)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (EntityBase<TId>)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item == this;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id?.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode ?? default;
            }
            else
                return base.GetHashCode();
        }
    }
}
