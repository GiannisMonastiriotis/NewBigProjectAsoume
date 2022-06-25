using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME.Models
{
    public class ArtistsBandsConnection
    {
        public Artist Artist { get; set; }

        public Band Band { get; set; }


        [Key]
        [Column(Order =1)]
        public int BandId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ArtistId  { get; set; }

      

    }
}