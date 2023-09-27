using Assignment_3.Data.DTOs.Characters;
using Assignment_3.Data.Models;
using AutoMapper;

namespace Assignment_3.Mappers
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDTO>()
                .ForMember(characterDto => characterDto.MovieIds, options => options
                    .MapFrom(character => character.Movies.Select(Movie => Movie.Id)));

            CreateMap<Character, CharactersListDTO>();
            CreateMap<Character, CharacterPostDTO>().ReverseMap();
            CreateMap<Character, CharacterPutDTO>().ReverseMap();
        }
    }
}
