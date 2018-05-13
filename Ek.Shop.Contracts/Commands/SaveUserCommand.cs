using Ek.Shop.Application.ApplicationUser;

namespace Ek.Shop.Contracts.Commands
{
    public class SaveUserCommand : ICommand
    {
        public SaveUserCommand()
        { }

        public SaveUserCommand(string routeUrl, UserDto user)
        {
            RouteUrl = routeUrl;
            User = user;
        }

        public string RouteUrl { get; set; }

        public UserDto User { get; set; }
    }
}
