namespace Ek.Shop.Application.Authentication
{
    public class LoginDataDto
    {
        public string Email { get; set; }

        public bool IsRemember { get; set; }

        public string Password { get; set; }

        public string RouteUrl { get; set; }
    }
}
