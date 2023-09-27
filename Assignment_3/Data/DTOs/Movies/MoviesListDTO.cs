namespace Assignment_3.Data.DTOs.Movies
{
    public class MoviesListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string? Director { get; set; }
        public string? PictureUrl { get; set; }
        public string? TrailerUrl { get; set; }
    }
}
