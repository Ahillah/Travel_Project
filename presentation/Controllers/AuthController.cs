using AutoMapper;
using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAuthService authService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _mapper = mapper;
        }



        [HttpPost("register/tourist")]
        public async Task<IActionResult> RegisterTourist([FromBody] TouristRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _mapper.Map<TouristUser>(dto);
            user.DisplayName = dto.UserName;
            user.UserType = "TOURIST";

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "TOURIST");

            return Ok(new { Message = "Tourist registered successfully" });
        }

        [HttpPost("register/hotel")]
        public async Task<IActionResult> RegisterHotel([FromBody] HotelRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var user = _mapper.Map<HotelUser>(dto);
            user.DisplayName = dto.HotelName;
            user.HotelId = dto.HotelId;
            user.UserType = "HOTEL";

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "HOTEL");

            return Ok(new { Message = "Hotel Admin registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return Unauthorized("Invalid Email or Password");

            var check = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!check) return Unauthorized("Invalid Email or Password");

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _authService.CreateTokenAsync(user, _userManager, roles.First());

            return Ok(new
            {
                IsSuccess = true,
                Token = token,
                Role = roles.First(),
                DisplayName = user.DisplayName
            });
        }


        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return NotFound("User not found");

            // Generate Code
            var code = new Random().Next(100000, 999999).ToString();

            user.ResetPasswordCode = code;
            user.ResetPasswordExpiry = DateTime.Now.AddMinutes(10);

            await _userManager.UpdateAsync(user);

            
            return Ok(new
            {
                Message = "Verification code sent",
                Code = code   // temporary
            });
        }

        [HttpPost("verify-code")]
        public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return NotFound("User not found");

            if (user.ResetPasswordCode != dto.Code)
                return BadRequest("Invalid code");

            if (user.ResetPasswordExpiry < DateTime.Now)
                return BadRequest("Code expired");

            return Ok(new { Message = "Code verified successfully" });
        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return NotFound("User not found");

            if (user.ResetPasswordCode != dto.VerificationCode)
                return BadRequest("Invalid or missing code");

            if (user.ResetPasswordExpiry < DateTime.Now)
                return BadRequest("Code expired");

            // Reset Password using token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Clear code
            user.ResetPasswordCode = null;
            user.ResetPasswordExpiry = null;
            await _userManager.UpdateAsync(user);

            return Ok(new { Message = "Password reset successfully" });
        }


    }
}



    
