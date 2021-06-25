﻿using DoctorAppWeb.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PatientsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthController(
                ILogger<AuthController> logger,
                UserManager<ApplicationUser> userManager, 
                SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;            
        }


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginRequest request)
        //{

        //    InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
        //    AuthResultDto authResult = await inpatientDoctorClient.AuthorizeAsync(request.UserName, request.Password);
        //    return authResult != null ? Ok() : BadRequest();
        //}

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            AuthResultDto authResult = await inpatientDoctorClient.AuthorizeAsync(request.UserName, request.Password);
            if (authResult != null)
            {
                var appUser = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = request.UserName,
                    Email = "noemail@mail.ru",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                try
                {
                    var userPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                    await _signInManager.SignInAsync(appUser, request.RememberMe);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest("Invalid login");
                }
            }
            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest parameters)
        {
            _logger.LogDebug("Register(..)");
            var user = new ApplicationUser();
            user.UserName = parameters.UserName;
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) 
                return BadRequest(result.Errors.FirstOrDefault()?.Description);

            return await Login(new LoginRequest
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            _logger.LogDebug("Logout(..)");
            await _signInManager.SignOutAsync();
            return Ok();
        }


        [HttpGet]
        public CurrentUser CurrentUserInfo()
        {

            _logger.LogDebug("CurrentUserInfo(..)");
            return new CurrentUser
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                Claims = User.Claims
                .ToDictionary(c => c.Type, c => c.Value)
            };
        }
    }
}
