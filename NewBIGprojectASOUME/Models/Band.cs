using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME.Models
{
    public class Band
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }

        //[NotMapped]
        //public Artist Artist { get; set; }

        public IEnumerable<Artist> Artists { get; set; }
    }
}