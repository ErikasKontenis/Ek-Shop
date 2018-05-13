namespace Ek.Shop.Contracts.Commands
{
    public class GetRouteByUrlCommand : ICommand
    {
        public GetRouteByUrlCommand()
        { }

        public GetRouteByUrlCommand(string url, int languageId)
        {
            Url = url;
            LanguageId = languageId;
        }

        public int LanguageId { get; set; }

        public string Url { get; set; }
    }
}
