using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHostel.DAL.Entites
{
    public class Apartment
    {
        [Key]
        public int Apartment_Id { get; set; }
        public required int Price { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public int FloorNum { get; set; }
        public int Num_Room { get; set; }
        public int Num_Bed { get; set; }
        public DateTime Publisheddate { get; set; } = DateTime.Now;
        public byte[] Apartment_Image { get; set; }
        public bool IsRented { get; set; } 
        public List<Comment>? Comments { get; set; }
        public string OwnerId { get; set; }
        public AppUser? Owner { get; set; }
        public string? StudentId { get; set; }
        public AppUser? Student { get; set; }

    }
}
