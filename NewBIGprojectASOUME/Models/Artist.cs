using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME.Models
{
    public class Artist
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<Band> Bands { get; set; }

        [NotMapped]
        public string FullName {
            get 
            {
                return $"{FirstName} {LastName}";

            } 
        }
    }
}