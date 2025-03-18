
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHostel.DAL.Entites
{
    public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        
          
            public required string FirstName { get; set; }

            public required string LastName { get; set; }
            public string UserType { get; set; } 

    }
}
