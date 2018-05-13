namespace Ek.Shop.Contracts.Commands
{
    public class GetCategoryByUrlCommand : ICommand
    {
        public GetCategoryByUrlCommand()
        { }

        public GetCategoryByUrlCommand(string url, int languageId)
        {
            Url = url;
            LanguageId = languageId;
        }
        
        public int LanguageId { get; set; }

        public string Url { get; set; }
    }
}
