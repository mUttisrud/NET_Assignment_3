
using AutoMapper;
using Assignment_3.Data.Models;
using Assignment_3.Data.DTOs.Movies;

namespace Assignment_3.Mappers
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<Movie, MovieGetDTO>()
                .ForMember(movieDto => movieDto.Characters, options => options
                    .MapFrom(movie => movie.Characters.Select(Character => Character.Name).ToArray()));

            CreateMap<Movie, MoviePostDTO>().ReverseMap();
            CreateMap<Movie, MoviePutDTO>().ReverseMap();
        }
    }
}
