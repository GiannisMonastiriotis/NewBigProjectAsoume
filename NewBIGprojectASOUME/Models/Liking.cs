using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME.Models
{
    public class Liking
    {
       

        [Key]
        [Column(Order = 1)]

        public string LikesId { get; set; }
        [Key]
        [Column(Order = 2)]

        public string LikeeId { get; set; }

        public ApplicationUser Likes { get; set; }

        public ApplicationUser Likee { get; set; }


    }

}