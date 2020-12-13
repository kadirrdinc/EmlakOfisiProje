using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EO.Data.Entities;
using EO.Data.Model;
using EO.Service;
using EO.Web.UI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EO.Web.UI.Controllers
{
    [Authorize(AuthenticationSchemes = "AgentCookieAuthentication")]
    public class NoticeController : Controller
    {
        private readonly INoticeService _noticeService;
        public NoticeController(INoticeService noticeService)
        {
            _noticeService = noticeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(NoticeViewModel model)
        {
            var returnModel = new ReturnModel();

            if (!ModelState.IsValid)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Formu Eksiksiz Doldurunuz";
                return Ok(returnModel);
            }

            var newNotice = new Notice
            {
                Description = model.Notice.Description,
                Address = model.Notice.Address,
                AgentId = int.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value),
                HouseAge = model.Notice.HouseAge,
                IsActive = true,
                IsFurnished = model.Notice.IsFurnished,
                HouseType = model.Notice.HouseType,
                NumberOfRooms = model.Notice.NumberOfRooms,
                SquareMeter = model.Notice.SquareMeter,
                Price = model.Notice.Price,
                StatusType = model.Notice.StatusType,
                CreatedBy = User.Identity.Name,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Identity.Name,
                UpdatedDate = DateTime.Now
            };

            try
            {
                _noticeService.Add(newNotice);
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new NoticeViewModel
            {
                Notice = _noticeService.GetById(id)
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(NoticeViewModel model)
        {
            var returnModel = new ReturnModel();

            if (!ModelState.IsValid)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Formu Eksiksiz Doldurunuz";
                return Ok(returnModel);
            }

            var editNotice = _noticeService.GetById(model.Notice.Id);

            editNotice.Description = model.Notice.Description;
            editNotice.Address = model.Notice.Address;
            editNotice.HouseAge = model.Notice.HouseAge;
            editNotice.HouseType = model.Notice.HouseType;
            editNotice.IsFurnished = model.Notice.IsFurnished;
            editNotice.HouseType = model.Notice.HouseType;
            editNotice.NumberOfRooms = model.Notice.NumberOfRooms;
            editNotice.SquareMeter = model.Notice.SquareMeter;
            editNotice.Price = model.Notice.Price;
            editNotice.StatusType = model.Notice.StatusType;
            editNotice.UpdatedBy = User.Identity.Name;
            editNotice.UpdatedDate = DateTime.Now;

            try
            {
                _noticeService.Update(editNotice);
                returnModel.IsSuccess = true;
                returnModel.Message = "Güncelleme Başarılı, Yönlendiriliyorsunuz";
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
            var notice = _noticeService.GetById(id);

            if (notice != null)
            {
                if (notice.IsActive != true)
                {
                    notice.IsActive = true;
                    notice.UpdatedDate = DateTime.Now;
                    notice.UpdatedBy = User.Identity.Name;
                }
                else
                {
                    notice.IsActive = false;
                    notice.UpdatedDate = DateTime.Now;
                    notice.UpdatedBy = User.Identity.Name;
                }

                try
                {
                    _noticeService.Update(notice);
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