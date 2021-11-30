using DoctorAppWeb.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PatientsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace DoctorAppWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        /*private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;*/
        /*        public AuthController(
                        ILogger<AuthController> logger,
                        UserManager<ApplicationUser> userManager, 
                        SignInManager<ApplicationUser> signInManager)
                {
                    _logger = logger;
                    _userManager = userManager;
                    _signInManager = signInManager;            
                }*/

        public AuthController(
                        ILogger<AuthController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            Guid? authResult = await inpatientDoctorClient.AuthorizeAsync(request.UserName, request.Password);
            if (authResult.HasValue)
            {
                var appUser = new ApplicationUser
                {
                    Id = authResult.ToString(),
                    UserName = request.UserName,
                    SecurityStamp = Guid.NewGuid().ToString()
                };                
                try
                {
                    //                    var userPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                    //await _signInManager.SignInAsync(appUser, request.RememberMe);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, appUser.UserName),
                        new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest("Invalid login");
                }
            }
            return BadRequest();
        }

        public async Task<UserInfoDto> GetUserInfo(string login)
        {
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            return await inpatientDoctorClient.GetUserInfoAsync(login);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest parameters)
        {
            var user = new ApplicationUser();
            user.UserName = parameters.UserName;
            /*                      var result = await _userManager.CreateAsync(user, parameters.Password);
                        if (!result.Succeeded) 
                            return BadRequest(result.Errors.FirstOrDefault()?.Description);*/
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            Guid? authResult = await inpatientDoctorClient.AuthorizeAsync(parameters.UserName, parameters.Password);
            if (!authResult.HasValue)
                return BadRequest("Contact the administrator for registration"); 

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
            //            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }


        [HttpGet]
        public CurrentUser CurrentUserInfo()
        {
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
