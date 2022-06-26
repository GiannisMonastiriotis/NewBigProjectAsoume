using NewBIGprojectASOUME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME.Viewmodels
{
    public class TopTenBandsViewModel
    {
        public int Artist { get; set; }

        public IEnumerable<Artist> Artists { get; set; }
        public string Name { get; set; }

        public int Band { get; set; }
        public IEnumerable<Band> Bands { get; set; }

        public int NumberOfArtists { get; set; }

        //public ICollection<Band> TopTenBands 
        //{  
        //    get
        //    {
        //        List<Band> Tenbands = new List<Band>();
        //        foreach (var band in Bands)
        //        {
        //            if(band.Artists.Count() > NumberOfArtists)
        //            {
                        
        //            }
        //        }
        //        return Tenbands;
        //    }
                
                
        //        }




    }
}