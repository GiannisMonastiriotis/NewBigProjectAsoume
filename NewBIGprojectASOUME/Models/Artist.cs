using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBIGprojectASOUME.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [RegularExpression(@"^[^,:*?""<>\|]*$")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[^,:*?""<>\|]*$")]
        public string LastName { get; set; }

        public IEnumerable<Band> Bands { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public IEnumerable<ArtistsBandsConnection> ArtistsBandsConnections { get; set; }
    }
}