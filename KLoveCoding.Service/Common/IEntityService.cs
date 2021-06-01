using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KLoveCoding.Service.Common
{
    public interface IEntityService<T, U, A>
    {
        Task Create(A dto);
        Task Update(A dto);
        List<string> Validate(U entity);
        Task<List<U>> GetAll();
    }
}
