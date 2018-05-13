namespace Ek.Shop.Contracts.Commands
{
    public class ListPhrasesByTermCommand : ICommand
    {
        public ListPhrasesByTermCommand()
        { }

        public ListPhrasesByTermCommand(string term)
        {
            Term = term;
        }

        public ListPhrasesByTermCommand(string term, string characteristic)
        {
            Term = term;
            Characteristic = characteristic;
        }

        public string Characteristic { get; set; }

        public string Term { get; set; }
    }
}
