using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.User;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.User;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Route("api/user/full/{id}")]
        public async Task<ActionResult<UserFullInfoResponse>> GetFullInfoById(Guid id)
        {
            var user = await _userService.GetFullInfoById(id);
            var userResponse = _mapper.Map<UserFullInfoServiceModel, UserFullInfoResponse>(user);

            return Ok(userResponse);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            UserServiceModel userServiceModel = await _userService.GetUserInfo(id);
            UserResponseModel userResponseModel = _mapper.Map<UserServiceModel, UserResponseModel>(userServiceModel);

            if (userResponseModel != null)
            {
                return Ok(userResponseModel);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Country
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User value)
        {
            await _userService.AddAsync(value);
            return Ok();
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]User value)
        {
            value.Id = id;
            await _userService.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.RemoveAsync(id);
            return Ok();
        }
    }
}