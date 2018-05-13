namespace Ek.Shop.Domain.InputForms
{
    public class InputFormOption : Classifier
    {
        public InputFormOption()
        { }

        public InputForm InputForm { get; set; }

        public int InputFormId { get; set; }
    }
}
