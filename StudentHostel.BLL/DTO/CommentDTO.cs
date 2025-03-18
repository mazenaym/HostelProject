using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHostel.BLL.DTO
{
    public class CommentDTO
    {
        public string Comment_Text { get; set; }
        public int? Apartment_Id { get; set; }
        public string? StudentId { get; set; }
    }
}
