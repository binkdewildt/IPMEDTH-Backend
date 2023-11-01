namespace IPMEDTH.Domain.Core.Entities.Base
{
    public interface IEntityBase<TId>
    {
        public TId Id { get; set; }
    }
}
