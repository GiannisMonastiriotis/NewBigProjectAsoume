using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME.Models
{
    public class Like
    {
        public Band Band { get; set; }

        public ApplicationUser Liked { get; set; }

        [Key]
        [Column(Order=1)]
        public int BandId { get; set; }


        [Key]
        [Column(Order = 2)]
        public string LikedId { get; set; }
    }
}