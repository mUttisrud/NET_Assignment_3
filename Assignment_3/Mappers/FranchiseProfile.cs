using Assignment_3.Data.DTOs.Franchises;
using Assignment_3.Data.Models;
using AutoMapper;

namespace Assignment_3.Mappers {
    public class FranchiseProfile: Profile {
        public FranchiseProfile() {
           CreateMap<Franchise, FranchiseGetDTO>().ReverseMap();
        }
    }
}
