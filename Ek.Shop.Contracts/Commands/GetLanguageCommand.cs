namespace Ek.Shop.Contracts.Commands
{
    public class GetLanguageCommand : ICommand
    {
        public GetLanguageCommand()
        { }

        public GetLanguageCommand(int languageId)
        {
            LanguageId = languageId;
        }

        public int LanguageId { get; set; }
    }
}
