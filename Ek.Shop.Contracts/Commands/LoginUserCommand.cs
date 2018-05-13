using Ek.Shop.Application.Authentication;

namespace Ek.Shop.Contracts.Commands
{
    public class LoginUserCommand : ICommand
    {
        public LoginUserCommand()
        { }

        public LoginUserCommand(LoginDataDto loginData)
        {
            LoginData = loginData;
        }

        public LoginDataDto LoginData { get; set; }
    }
}
