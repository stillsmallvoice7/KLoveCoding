using AutoMapper;
using KLoveCoding.DAL.Models;
using KLoveCoding.Service.Interfaces.Mapping;
using System.ComponentModel.DataAnnotations;

namespace KLoveCoding.Service.Dtos
{
    public class FavoriteDto : IHaveCustomMapping
    {
        public int Id { get; set; }

        [Display(Name = "Verse")]
        public string VerseText { get; set; }
        [Display(Name = "Image")]
        public string ImageLink { get; set; }
        public string VerseApiId { get; set; }
        public bool IsActive { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Favorite, FavoriteDto>();
        }
    }
}
