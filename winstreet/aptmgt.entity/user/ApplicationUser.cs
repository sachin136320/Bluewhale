using System;
using Microsoft.AspNetCore.Identity;


namespace aptmgt.entity.user
{
    public class ApplicationUser : IdentityUser
    {
        public string CommunityID {get; set;}
        
    }
}
