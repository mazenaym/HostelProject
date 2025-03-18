using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHostel.DAL.Entites
{
    public class Student :AppUser
    {
        public long Phone { get; set; }

        public string? College { get; set; }

      

    }
}
