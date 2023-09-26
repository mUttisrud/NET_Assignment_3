using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Data.DTOs.Movies
{
    public class MoviePostDTO
    {
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string? Director { get; set; }
        [MaxLength(50)]
        public string? PictureUrl { get; set; }
        [MaxLength(50)]
        public string? TrailerUrl { get; set; }
        public int FranchiseId { get; set; }
    }
}
