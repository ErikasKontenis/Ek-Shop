namespace Ek.Shop.Domain
{
    public abstract class Classifier : Entity
    {
        public string Code { get; set; }

        public string Value { get; set; }
    }
}
