using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Data.DTOs.Characters
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(50)]
        public string? Alias { get; set; }
        [MaxLength(50)]
        public string Gender { get; set; } = null!;
        [MaxLength(50)]
        public string? PictureUrl { get; set; }
        public string[] Movies { get; set; }
    }
}
