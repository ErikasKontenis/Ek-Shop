namespace Ek.Shop.Contracts.Commands
{
    public class GetRouteByComponentCommand : ICommand
    {
        public GetRouteByComponentCommand()
        { }

        public GetRouteByComponentCommand(string component)
        {
            Component = component;
        }

        public string Component { get; set; }
    }
}
