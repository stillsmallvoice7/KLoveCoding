using AutoMapper;
using KLoveCoding.DAL.Models;
using KLoveCoding.Service.Interfaces.Mapping;

namespace KLoveCoding.Service.Dtos
{
    public class FavoriteActionDto : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string VerseText { get; set; }
        public string ImageLink { get; set; }
        public string VerseApiId { get; set; }
        public bool IsActive { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Favorite, FavoriteActionDto>();
            configuration.CreateMap<FavoriteActionDto, Favorite>();
        }
    }
}
