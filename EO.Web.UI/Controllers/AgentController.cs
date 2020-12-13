using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EO.Data.Entities;
using EO.Data.Model;
using EO.Service;
using EO.Web.UI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EO.Web.UI.Controllers
{
    [Authorize(AuthenticationSchemes = "AgentCookieAuthentication")]
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;
        private readonly INoticeService _noticeService;
        public AgentController(IAgentService agentService, INoticeService noticeService)
        {
            _agentService = agentService;
            _noticeService = noticeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            int id = int.Parse(User.FindFirst(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            var model = _agentService.GetById(id);

            var agentModel = new AgentViewModel()
            {
                Id = model.Id,
                CompanyName = model.CompanyName,
                CreatedBy = model.CreatedBy,
                ConfirmPassword = model.ConfirmPassword,
                CreatedDate = model.CreatedDate,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = model.IsActive,
                Password = model.Password,
                UpdatedBy = model.UpdatedBy,
                UpdatedDate = model.UpdatedDate,
                UserName = model.UserName
            };

            return View(agentModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(AgentViewModel agent)
        {
            var returnModel = new ReturnModel();

            if (!ModelState.IsValid)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Formu Eksiksiz Doldurunuz";
                return Ok(returnModel);
            }

            if (agent.Password != null && agent.ConfirmPassword == null)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Şifre Tekrarı Boş Geçilemez!";
                return Ok(returnModel);
            }

            int id = int.Parse(User.FindFirst(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            var model = _agentService.GetById(id);

            model.FirstName = agent.FirstName;
            model.LastName = agent.LastName;
            model.CompanyName = agent.CompanyName;
            model.UpdatedBy = User.Identity.Name;
            model.UpdatedDate = DateTime.Now;

            if (agent.Password != null)
            {
                model.Password = agent.Password;
                model.ConfirmPassword = agent.ConfirmPassword;
            }
            else
            {
                model.ConfirmPassword = model.Password;
            }


            try
            {
                _agentService.Update(model);
                returnModel.IsSuccess = true;
                returnModel.Message = "Kayıt Başarılı, Yönlendiriliyorsunuz";
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