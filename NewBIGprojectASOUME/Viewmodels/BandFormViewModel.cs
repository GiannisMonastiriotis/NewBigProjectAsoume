using NewBIGprojectASOUME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME
{
    public class BandFormViewModel
    {
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        public byte Artist { get; set; }
    
        public IEnumerable<Artist>  Artists { get; set; }

        public string Name { get; set; }

        public byte Band { get; set; }
        public IEnumerable<Band> Bands { get; set; }

    }
}