using AutoMapper;
using MVC.Core.Entities;
using MVC.ViewModels;

namespace MVC.Database
{
    public static class ObjectsMapper
    {
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArtistViewModel, Artist>();
                cfg.CreateMap<ArtistViewModel, PortfolioViewModel>();
                cfg.CreateMap<ArtistViewModel, Followers>();
                cfg.CreateMap<ArtistViewModel, Reactions>();
                cfg.CreateMap<PostViewModel, Post>();
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<Artist, ArtistViewModel>();
                cfg.CreateMap<PortfolioViewModel, Artist>();
                cfg.CreateMap<Artist, Followers>();

            }).CreateMapper();
        }
    }
}
