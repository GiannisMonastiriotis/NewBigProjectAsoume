using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [RegularExpression(@"^[^,:*?""<>\|]*$")]

        public string Name { get; set; }
    }
}