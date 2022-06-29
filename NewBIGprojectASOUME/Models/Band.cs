using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewBIGprojectASOUME.Models
{
    public class Band
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[^,:*?""<>\|]*$")]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        //[NotMapped]
        public virtual IEnumerable<Artist> Artists { get; set; }

        public IEnumerable<ArtistsBandsConnection> ArtistsBandsConnections { get; set; }
        //  public virtual IEnumerable<ArtistsBandsConnection> ArtistsBands { get; set; }

        // [NotMapped]
        // [PastDate]
        //public DateTime DateTimeProvided { get; set; }
    }
}