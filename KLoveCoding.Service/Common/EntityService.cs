using AutoMapper;
using KLoveCoding.DAL.Common;
using KLoveCoding.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLoveCoding.Service.Common
{
    public abstract class EntityService<T, U, A> : IEntityService<T, U, A> where T : BaseEntity
    {
        protected Context _context;
        public readonly IMapper _mapper;
        protected DbSet<T> _dbset;

        public EntityService(Context context, IMapper mapper)
        {
            _context = context;
            _dbset = _context.Set<T>();
            _mapper = mapper;
        }

        public virtual async Task Create(A dto)
        {
            if (dto == null)
            {
                throw new ArgumentException("dto");
            }

            var entity = MapDtoToEntity(dto);

            _dbset.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(A dto)
        {
            if (dto == null)
            {
                throw new ArgumentException("dto");
            }

            var entity = _mapper.Map<T>(dto);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual List<string> Validate(U entity)
        {
            List<string> errors = new List<string>();

            return errors;
        }

        public virtual async Task<List<U>> GetAll()
        {
            var entity = await _dbset.ToListAsync();
            var result = _mapper.Map<List<U>>(entity);
            return result;
        }

        public T MapDtoToEntity(A dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }

            var entity = _mapper.Map<T>(dto);

            return entity;
        }
    }
}
