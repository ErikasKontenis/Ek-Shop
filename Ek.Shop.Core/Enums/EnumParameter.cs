namespace Ek.Shop.Core.Enums
{
    public sealed class EnumParameter
    {
        public EnumParameter(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
