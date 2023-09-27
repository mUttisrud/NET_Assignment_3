using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Data.DTOs.Franchises {
    public class FranchisePostDTO {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Desciption { get; set; }
    }
}
