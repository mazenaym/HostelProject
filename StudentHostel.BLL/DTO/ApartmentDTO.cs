using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHostel.BLL.DTO
{
    public class ApartmentDTO
    {
        public required int Price { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public int FloorNum { get; set; }
        public int Num_Room { get; set; }
        public int Num_Bed { get; set; }
        public DateTime Publisheddate { get; set; } = DateTime.Now;
        public IFormFile Apartment_Image { get; set; }
        public bool IsRented { get; set; }
    }
}
