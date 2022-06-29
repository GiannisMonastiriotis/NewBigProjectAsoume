using NewBIGprojectASOUME.Models;
using System.Collections.Generic;

namespace NewBIGprojectASOUME.Viewmodels
{
    public class BandViewModel
    {
        public int Artist { get; set; }
        public string Heading { get; set; }

        public IEnumerable<Band> FeauturedBands { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Band> Bands { get; set; }
        public string Name { get; set; }

        public int Band { get; set; }

        public int NumberOfArtists { get; set; }

        public bool ShowActions { get; set; }
    }
}