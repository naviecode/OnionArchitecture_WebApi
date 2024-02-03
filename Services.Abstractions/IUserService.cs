using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserDto>GetbyIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<UserDto> CreateAsync(UserForCreationDto userDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid userId,UserForUpdateDto userDto, CancellationToken cancellationToken= default);
    }
}
