namespace Ek.Shop.Contracts.Commands
{
    public class GetRouteCommand : ICommand
    {
        public GetRouteCommand()
        { }

        public GetRouteCommand(int routeId)
        {
            RouteId = routeId;
        }

        public GetRouteCommand(string url)
        {
            Url = url;
        }

        public int? RouteId { get; set; }

        public string Url { get; set; }
    }
}
