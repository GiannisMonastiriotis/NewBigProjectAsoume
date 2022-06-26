using NewBIGprojectASOUME.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME
{
    public class BandFormViewModel
    {   
        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        [Required]
        public int Artist { get; set; }
    
        public virtual IEnumerable<Artist>  Artists { get; set; }

        [Required]
        public string Name { get; set; }
        public int Band { get; set; }
        public IEnumerable<Band> Bands { get; set; }
        public DateTime DateTimeProvided { get; set; }

        public DateTime DateTimeCreated
        {
            get
            {
                var Date = DateTime.Now;
                return Date;
            }
        }
    }
}