﻿using System.Threading.Tasks;
using AutoMapper;
using BattleTanks.Core.DTOs;
using BattleTanks.Core.IService;
using BattleTanks.DB.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattleTanks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthenticationController(
            IUserService userSrv,
            IMapper mapper,
            IAuthService authSrv
            )
        {
            _userService = userSrv;
            _mapper = mapper;
            _authService = authSrv;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody]LoginDto model)
        {
            var result = _authService.Authenticate(model.Email, model.Password);
            if (!result.Successed)
            {
                return BadRequest(result.Message);
            }

            var user = _userService.GetByEmail(model.Email);

            var userInfo = _mapper.Map<UserInfo>(user);
            userInfo.Token = result.Message;

            return Ok(userInfo);   
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto authRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var user = _mapper.Map<RegisterDto, UserDto>(authRequest);              

            var result = await _userService.Create(user);
            if (!result.Successed)
            {
                return BadRequest(result.Message);
            }
            return Ok();
        }
    }
}