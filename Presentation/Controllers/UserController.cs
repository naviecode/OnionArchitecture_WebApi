using Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IServiceManager _serviceManager;
        public UserController(ILogger<UserController> logger, IServiceManager serviceManager)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var userDto = await _serviceManager.UserService.GetAllAsync(cancellationToken);

            return Ok(userDto);
        }
        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserById(Guid userId, CancellationToken cancellationToken)
        {
            var userDto = await _serviceManager.UserService.GetbyIdAsync(userId, cancellationToken);

            if(userDto is null)
            {
                return Content("No found");
            }    

            return Ok(userDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserForCreationDto userForCreationDto, CancellationToken cancellationToken)
        {
            var reponse = await _serviceManager.UserService.CreateAsync(userForCreationDto, cancellationToken);

            return Ok(reponse);
        }
        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateUser(Guid userId, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.UpdateAsync(userId, userForUpdateDto, cancellationToken);

            return NoContent();
        }
        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.DeleteAsync(userId, cancellationToken);

            return Ok();
        }

        
    }
}
