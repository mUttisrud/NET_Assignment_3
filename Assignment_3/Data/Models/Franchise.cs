using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_3.Data.Models
{
    [Table("Franchise")]
    public class Franchise
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(200)]
        public string? Description { get; set; }

        //Connection to Movies
        public List<Movie>? Movies { get; set; }
    }
}
