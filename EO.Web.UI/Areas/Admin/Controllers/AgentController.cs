using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EO.Data.Entities;
using EO.Data.Model;
using EO.Service;
using EO.Web.UI.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EO.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = "AdminCookieAuthentication")]
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(AgentViewModel model)
        {
            ReturnModel returnModel = new ReturnModel();

            if (!ModelState.IsValid)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Formu Eksiksiz Doldurunuz";
                return Ok(returnModel);
            }

            var newAgent = new Agent
            {
                FirstName = model.Agent.FirstName,
                LastName = model.Agent.LastName,
                UserName = model.Agent.UserName,
                CompanyName = model.Agent.CompanyName,
                Role = model.Agent.Role,
                Password = model.Agent.Password,
                ConfirmPassword = model.Agent.ConfirmPassword,
                IsActive = true,
                CreatedBy = User.Identity.Name,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Identity.Name,
                UpdatedDate = DateTime.Now
            };



            try
            {
                _agentService.Add(newAgent);
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            ReturnModel returnModel = new ReturnModel();
            var agent = _agentService.GetById(id);

            if (agent != null)
            {
                if (agent.IsActive != true)
                {
                    agent.IsActive = true;
                    agent.UpdatedDate = DateTime.Now;
                    agent.UpdatedBy = User.Identity.Name;
                }
                else
                {
                    agent.IsActive = false;
                    agent.UpdatedDate = DateTime.Now;
                    agent.UpdatedBy = User.Identity.Name;
                }

                try
                {
                    _agentService.Update(agent);
                    returnModel.IsSuccess = true;
                    returnModel.Message = "Güncellendi";
                }
                catch (Exception ex)
                {
                    returnModel.IsSuccess = false;
                    returnModel.Message = "Hata Oluştu" + ex.Message;
                }
            }
            else
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Kullanıcı Bulunamadı";
            }
            return Ok(returnModel);
        }
    }
}