using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restaurant_Management_Task.Authentication;
using Restaurant_Management_Task.Dtos;
using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Controllers
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly AuthReopository _reopository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public IConfiguration Config { get; }

        public AuthController(AuthReopository reopository, IMapper mapper,IConfiguration config)
        {
            _reopository = reopository;
            _mapper = mapper;
            _config = config;
           
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            try
            {
                userRegisterDto.email = userRegisterDto.email.ToLower();
                if (await _reopository.UserExisits(userRegisterDto.email))
                    return BadRequest("the user has been exisists");

                var CreateModel = _mapper.Map<User>(userRegisterDto);
                _ = _reopository.Register(CreateModel, userRegisterDto.password);

            }
            catch(Exception ex)
            {
                ex.Message.ToLower();

                return StatusCode(400);
            }
            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpPost("login")]

        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var userLogin = await _reopository.Login(userLoginDto.email.ToLower(), userLoginDto.password);
            if (userLogin == null) return Unauthorized();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userLogin.id.ToString()),
                new Claim(ClaimTypes.Name,userLogin.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds

            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                token = TokenHandler.WriteToken(token)

            });

        
        }





    }
}
