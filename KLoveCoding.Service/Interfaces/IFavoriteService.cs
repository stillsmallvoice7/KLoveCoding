using KLoveCoding.DAL.Models;
using KLoveCoding.Service.Common;
using KLoveCoding.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KLoveCoding.Service.Interfaces
{
    public interface IFavoriteService : IEntityService<Favorite, FavoriteDto, FavoriteActionDto>
    {
        Task<List<string>> Validate(FavoriteActionDto dto, bool newRecord, string editUrl);
    }
}
