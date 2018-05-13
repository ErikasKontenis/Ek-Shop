namespace Ek.Shop.Core.Models
{
    public sealed class Option<T>
    {
        public Option(string name, T defaultValue = default(T))
        {
            Name = name;
            DefaultValue = defaultValue;
        }

        public string Name { get; set; }

        public T DefaultValue { get; set; }
    }
}
