namespace Ek.Shop.Contracts.Commands
{
    public class GetPhraseByValueCommand : ICommand
    {
        public GetPhraseByValueCommand()
        { }

        public GetPhraseByValueCommand(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
