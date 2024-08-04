using AutoMapper;
using PokemonReview.Models.Dtos.Responses;
using PokemonReview.Models.Entities;

namespace PokemonReview;

public class PokemonProfile : Profile
{
  public PokemonProfile()
  {
    CreateMap<Pokemon, GetPokemonDto>();
    CreateMap<Pokemon, GetPokemonWithOwnerDto>()
      .ForMember(
        dest => dest.OwnerNames,
        opt => opt.MapFrom(src => src.Owners.Select(o => o.Name))
      );

    CreateMap<AddPokemonDto, Pokemon>().ForMember(dest => dest.Owners, opt => opt.MapFrom(src => new List<Owner> { new(src.OwnerName) }));
  }
}
