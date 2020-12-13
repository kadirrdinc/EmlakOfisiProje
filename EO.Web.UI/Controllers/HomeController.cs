using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EO.Web.UI.Models;
using Microsoft.AspNetCore.Authorization;
using EO.Data.Model;
using EO.Service;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using EO.Web.UI.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EO.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAgentService _agentService;
        private readonly INoticeService _noticeService;
        public HomeController(IAgentService agentService, INoticeService noticeService)
        {
            _agentService = agentService;
            _noticeService = noticeService;
        }

        [Authorize(AuthenticationSchemes = "AgentCookieAuthentication")]
        public IActionResult Index()
        {
            int id = int.Parse(User.FindFirst(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            var model = new NoticeViewModel
            {
                Notices = _noticeService.GetAllInclude(id)
            };
            return View(model);
        }

        [HttpGet]
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
            var agent = _agentService.Login(model.UserName, model.Password);

            if (agent != null && agent.IsActive != false)
            {
                var identity = new ClaimsIdentity(new[] {
                     new Claim(ClaimTypes.Name,agent.UserName),
                     new Claim(ClaimTypes.NameIdentifier,agent.Id.ToString()),
                    new Claim(ClaimTypes.Role,agent.Role),
                    new Claim(ClaimTypes.DateOfBirth,agent.CreatedDate.ToString()),
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync("AgentCookieAuthentication", principal);

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

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (User.Claims == null || !User.Claims.Any())
                return Redirect("~/Home/Login");

            await HttpContext.SignOutAsync();
            return Redirect("~/Home/Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
