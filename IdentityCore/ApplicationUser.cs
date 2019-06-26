using Microsoft.AspNetCore.Identity;


namespace Edura.WebUI.IdentityCore
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
