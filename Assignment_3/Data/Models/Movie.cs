using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_3.Data.Models
{

    [Table("Movie")]
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(50)]
        public string Genre { get; set; } = null!;
        [MaxLength(40)]
        public int ReleaseYear { get; set; }
        [MaxLength(50)]
        public string? Director { get; set; }
        [MaxLength(50)]
        public string? PictureUrl { get; set; }
        [MaxLength(50)]
        public string? TrailerUrl { get; set; }

        //Connection to Characters
        public ICollection<Character> Characters { get; set; } = new List<Character>();

        //Connection to Franchise
        public int FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }

    }
}