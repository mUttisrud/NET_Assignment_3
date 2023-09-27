using Assignment_3.Data.DTOs.Franchises;
using Assignment_3.Data.Models;
using AutoMapper;

namespace Assignment_3.Mappers {
    public class FranchiseProfile: Profile {
        public FranchiseProfile() {
            CreateMap<Franchise, FranchiseDTO>()
                .ForMember(franchiseDTO => franchiseDTO.MovieIds, options => options
                    .MapFrom(franchise => franchise.Movies.Select(movie => movie.Id)));

            CreateMap<Franchise, FranchisePostDTO>().ReverseMap();
            CreateMap<Franchise, FranchisePutDTO>().ReverseMap();

        }
    }
}
