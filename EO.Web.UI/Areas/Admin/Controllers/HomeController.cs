using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EO.Data.Entities;
using EO.Data.Model;
using EO.Service;
using EO.Web.UI.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EO.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IAgentService _agentService;
        public HomeController(IAdminService adminService, IAgentService agentService)
        {
            _adminService = adminService;
            _agentService = agentService;
        }

        [Authorize(AuthenticationSchemes = "AdminCookieAuthentication")]
        public IActionResult Index()
        {
            var model = new AgentViewModel
            {
                Agents = _agentService.GetAll()
            };
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var returnModel = new ReturnModel();
            if (!ModelState.IsValid)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Formu Eksiksiz Doldurunuz";
                return Ok(returnModel);
            }
            var admin = _adminService.Login(model.UserName, model.Password);

            if (admin != null)
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,admin.UserName),
                    new Claim(ClaimTypes.NameIdentifier,admin.Id.ToString()),
                    new Claim(ClaimTypes.Role,admin.Role),
                    new Claim(ClaimTypes.DateOfBirth,admin.CreatedDate.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync("AdminCookieAuthentication", principal);

                returnModel.IsSuccess = true;
                returnModel.Message = "Giriş Başarılı";
            }
            else
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Giriş Başarısız";
            }
            return Ok(returnModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if (User.Claims == null || !User.Claims.Any())
                return Redirect("~/Admin/Home/Login");

            await HttpContext.SignOutAsync();
            return Redirect("~/Admin/Home/Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(AdminUser adminUser)
        {
            var returnModel = new ReturnModel();

            if (!ModelState.IsValid)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Formu Eksiksiz Doldurunuz";
                return Ok(returnModel);
            }

            var uniqueUserName = _adminService.GetByUserName(adminUser.UserName);

            if (uniqueUserName != null)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Bu Kullanıcı Adı Sistemde Kayıtlı!";
                return Ok(returnModel);
            }

            var admin = new AdminUser
            {
                FirstName = adminUser.FirstName,
                LastName = adminUser.LastName,
                Password = adminUser.Password,
                ConfirmPassword = adminUser.ConfirmPassword,
                UserName = adminUser.UserName,
                CreatedBy = adminUser.UserName,
                CreatedDate = DateTime.Now,
                UpdatedBy = adminUser.UserName,
                UpdatedDate = DateTime.Now,
                Role = adminUser.Role
            };


            try
            {
                _adminService.Add(admin);
                returnModel.IsSuccess = true;
                returnModel.Message = "Kayıt Başarılı";
            }
            catch (Exception ex)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Hata Oluştu" + ex.Message;
            }

            return Ok(returnModel);
        }



    }
}