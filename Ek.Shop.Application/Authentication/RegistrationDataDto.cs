namespace Ek.Shop.Application.Authentication
{
    public class RegistrationDataDto
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public string PhoneNumber { get; set; }

        public string RouteUrl { get; set; }
    }
}
