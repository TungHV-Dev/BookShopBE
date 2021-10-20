using BookShopBE.Common.Constants;
using BookShopBE.Common.Dtos;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShopBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(Roles = RoleDetails.ADMINISTRATOR)]
    public class UserController : ControllerBase
    {
        #region Properties
        private readonly IUserServices _userServices;
        #endregion Properties

        #region Contructor
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        #endregion Contructor

        #region Public
        [HttpGet]
        [Route("Get-All-Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] BaseQuery query)
        {
            var response = await _userServices.GetAllUsers(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("Get-User")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var response = await _userServices.GetUser(userId);
            if(!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Update-User")]
        public async Task<IActionResult> UpdateUser([FromForm] UserDto userDto)
        {
            var response = await _userServices.UpdateUser(userDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete-User")]
        public async Task<IActionResult> DeleteUSer(string userId)
        {
            var response = await _userServices.DeleteUser(userId);
            if(!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        #endregion Public
    }
}
