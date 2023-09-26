using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_3.Data.Models
{
    [Table("Character")]
    public class Character
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(50)]
        public string? Alias { get; set; }
        [MaxLength(50)]
        public string Gender { get; set; } = null!;
        [MaxLength(50)]
        public string? PictureUrl { get; set;}

        //Connection to Movies
        public List<Movie> Movies { get; set;}
    }
}
