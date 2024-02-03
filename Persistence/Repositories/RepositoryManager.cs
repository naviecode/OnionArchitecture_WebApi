using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyUserRepository = new Lazy<IUserRepository>(()=> new UserRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(()=> new UnitOfWork(dbContext));
        }

        public IUserRepository UserRepository => _lazyUserRepository.Value; 
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value; 
    }
}
