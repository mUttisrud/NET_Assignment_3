using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Data.DTOs.Franchises {
    public class FranchisePutDTO {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; } = null!;
    }
}
