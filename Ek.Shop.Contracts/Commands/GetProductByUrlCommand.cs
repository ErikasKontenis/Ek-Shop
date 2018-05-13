namespace Ek.Shop.Contracts.Commands
{
    public class GetProductByUrlCommand : ICommand
    {
        public GetProductByUrlCommand()
        { }

        public GetProductByUrlCommand(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}
