using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public UserRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<User>> GetAllUserAsync(CancellationToken cancellationToken = default)
        {
           return await _dbContext.Users.ToListAsync(cancellationToken);
        }

        public async Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken) ?? new User();
        }

        public void Inser(User user)
        {
             _dbContext.Users.Add(user);
        }

        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);
        }
    }
}
