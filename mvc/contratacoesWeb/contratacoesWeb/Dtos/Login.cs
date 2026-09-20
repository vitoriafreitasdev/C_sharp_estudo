
//Login
using Microsoft.AspNetCore.Identity;

namespace contratacoesWeb.Dtos
{
    public class Login : IdentityUser
    {
        public string email { get; set; }
        public string senha { get; set; }
    }
}
