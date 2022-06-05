using AutoMapper;
using JokeApi.Data;
using JokeApi.Models.Comment;
using JokeApi.Models.Joke;

namespace JokeApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Joke, CreateJokeDto>().ReverseMap();
            CreateMap<Joke, GetJokeDto>().ReverseMap();
            CreateMap<Joke, JokeDto>().ReverseMap();
            CreateMap<Joke, UpdateJokeDto>().ReverseMap();


            CreateMap<Comment, CommentDto>().ReverseMap();

        }
    }
}
