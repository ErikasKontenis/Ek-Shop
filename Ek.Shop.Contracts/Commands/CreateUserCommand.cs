using Ek.Shop.Application.Authentication;

namespace Ek.Shop.Contracts.Commands
{
    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand()
        { }

        public CreateUserCommand(RegistrationDataDto registrationData)
        {
            RegistrationData = registrationData;
        }

        public RegistrationDataDto RegistrationData { get; set; }
    }
}
