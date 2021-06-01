using AutoMapper;
using KLoveCoding.DAL.Data;
using KLoveCoding.DAL.Models;
using KLoveCoding.Service.Common;
using KLoveCoding.Service.Dtos;
using KLoveCoding.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLoveCoding.Service.Implementations
{
    public class FavoriteService : EntityService<Favorite, FavoriteDto, FavoriteActionDto>, IFavoriteService
    {
        public FavoriteService(Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _dbset = _context.Set<Favorite>();
        }

        public async Task<List<string>> Validate(FavoriteActionDto dto, bool newRecord, string editUrl)
        {
            List<string> errors = new List<string>();

            var numberOfVerseAPIRecords = _dbset.Where(i => i.VerseApiId == dto.VerseApiId).Count();

            if (numberOfVerseAPIRecords > 0)
            {
                errors.Add("This item is already in your favorites!");
            }

            return errors;
        }
    }
}
