namespace Ek.Shop.Contracts.Commands
{
    public class ListRoutesCommand : ICommand
    {
        public ListRoutesCommand()
        { }

        public ListRoutesCommand(int routeId)
        {
            RouteId = routeId;
        }

        public ListRoutesCommand(string url)
        {
            Url = url;
        }

        public int? RouteId { get; set; }

        public string Url { get; set; }
    }
}
