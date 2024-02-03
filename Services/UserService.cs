using Contracts;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Domain.Entities;

namespace Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto, CancellationToken cancellationToken = default)
        {
            var user = userForCreationDto.Adapt<User>();
            _repositoryManager.UserRepository.Inser(user);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return user.Adapt<UserDto>();

        }
        public async Task UpdateAsync(Guid userId, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);
            user.Name = userForUpdateDto.Name;
            user.BirthDay = userForUpdateDto.BirthDay;
            user.Address = userForUpdateDto.Address;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);

            if(user is null)
            {
                throw new NotImplementedException();
            }

            _repositoryManager.UserRepository.Remove(user);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await _repositoryManager.UserRepository.GetAllUserAsync(cancellationToken);

            return users.Adapt<IEnumerable<UserDto>>();
        }

        public async Task<UserDto> GetbyIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);
            if(user is null)
            {
                throw new NotImplementedException();
            }

            return user.Adapt<UserDto>();
        }
    }
}
