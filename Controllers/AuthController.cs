using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MKBase.Service.AuthService;
using MKBase.Models;
using MKBase.Dto.User;
using Microsoft.AspNetCore.Authorization;

namespace MKBase.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<ServiceResponse<GetUserDto>> Register(RegisterUserDto request)
        {
            ServiceResponse<GetUserDto> response = _authService.Register(request);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public ActionResult<ServiceResponse<string>> Login(LoginUserDto request)
        {
            ServiceResponse<string> response = _authService.Login(request);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPost("reset/password")]
        public ActionResult<ServiceResponse<GetUserDto>> ResetPassword(ResetUserPasswordDto request)
        {
            ServiceResponse<GetUserDto> response = _authService.ResetPasword(request);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPost("reset/email")]
        public ActionResult<ServiceResponse<GetUserDto>> ResetEmail(string email)
        {
            ServiceResponse<GetUserDto> response = _authService.ResetEmail(email);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPost("code/send")]
        public async Task<ActionResult> SendValidationEmail()
        {
            await _authService.SendValidationEmail();
            return Ok();
        }

        [Authorize]
        [HttpPost("code/{code:int}")]
        public ActionResult<ServiceResponse<GetUserDto>> EnterValidationCode(string code)
        {
            ServiceResponse<GetUserDto> response = _authService.EnterValidationCode(code);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}