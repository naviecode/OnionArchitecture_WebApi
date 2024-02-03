using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync(CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        void Inser(User user);
        void Remove(User user);
    }
}
