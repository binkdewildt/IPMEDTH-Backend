namespace IPMEDTH.Domain.Application.Models.Base
{
    public class Model
    {
        public string Id { get; set; } = string.Empty;


        public override bool Equals(object? obj)
        {
            if (obj is Model model)
                return this.Id == model.Id && base.Equals(obj);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
