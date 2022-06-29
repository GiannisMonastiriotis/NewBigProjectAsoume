using System.ComponentModel.DataAnnotations;

namespace NewBIGprojectASOUME.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [RegularExpression(@"^[^,:*?""<>\|]*$")]
        public string Name { get; set; }
    }
}