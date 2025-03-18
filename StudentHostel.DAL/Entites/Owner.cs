using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHostel.DAL.Entites
{
    public class Owner:AppUser
    {
        public long Phone { get; set; }

        public List<Apartment> Apartments { get; set; }
    }
}
