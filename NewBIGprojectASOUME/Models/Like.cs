using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBIGprojectASOUME.Models
{
    public class Like
    {
        public Band Band { get; set; }

        public ApplicationUser Liked { get; set; }

        [Key]
        [Column(Order = 1)]
        public int BandId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string LikedId { get; set; }
    }
}