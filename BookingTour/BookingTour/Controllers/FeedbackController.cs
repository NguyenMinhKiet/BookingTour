using Application.DTOs.FeedbackDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ICustomerService _customerService;
        public FeedbackController(IFeedbackService feedbackService, ICustomerService customerService)
        {
            _feedbackService = feedbackService;
            _customerService = customerService;
        }

        // GET: /Feedback/
        public async Task<IActionResult> Index()
        {
            var feedbacks = await _feedbackService.GetAllAsync();
            var feedbacksViewModel = feedbacks.Select(i => new FeedbackViewModel
            {
                FeedbackID = i.FeedbackID,
                CustomerID = i.CustomerID,
                TourID = i.TourID,
                Rating = i.Rating,
                Comments = i.Comments,
                CreateAt = i.CreateAt,
                ModifyAt = i.ModifyAt
            }).ToList();

            return View(feedbacksViewModel);
        }


        // GET: /Feedback/Create
        public async Task<IActionResult> Create()
        {
            var customers = await _customerService.GetAllAsync();
            // Customer
            var customersViewModel = customers.Select(i=> new CustomerViewModel
            {
                CustomerID = i.CustomerID,
                LastName = i.LastName,
            }).ToList();

            // Tạo SelectList cho dropdown khách hàng
            var customersSelectList = new SelectList(customersViewModel, "CustomerID", "LastName");

            // Đưa SelectList vào ViewBag
            ViewBag.CustomerList = customersSelectList;

            return View();
        }


        // POST: /Feedback/Create
        [HttpPost]
        public async Task<IActionResult> Create(FeedbackCreationDto dto)
        {
            if(ModelState.IsValid)
            {
                await _feedbackService.CreateAsync(dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = $"Thêm đánh giá cho Tour {dto.TourID} thành công";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Dữ liệu nhập không hợp lệ";
            return View();
        }

        // GET: /Feedback/Update?{FeedbackID}
        public async Task<IActionResult> Update(Guid FeedbackID)
        {
            var feedback = await _feedbackService.GetById(FeedbackID);
            if(feedback != null)
            {
                var feedbackViewModel = new FeedbackViewModel
                {
                    FeedbackID = feedback.FeedbackID,
                    CustomerID = feedback.CustomerID,
                    TourID = feedback.TourID,
                    Rating = feedback.Rating,
                    Comments = feedback.Comments,
                    CreateAt = feedback.CreateAt,
                    ModifyAt = feedback.ModifyAt
                };
                return View(feedbackViewModel);
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không tìm thấy đánh giá id: {FeedbackID}";
            return RedirectToAction("Index");
        }

        // POST: /Feedback/Update?{FeedbackID}
        [HttpPost]
        public async Task<IActionResult> Update(Guid FeedbackID, FeedbackUpdateDto dto)
        {
            if(ModelState.IsValid)
            {
                await _feedbackService.UpdateAsync(FeedbackID, dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = $"Cập nhật thông tin đánh giá thành công";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View();
        }
    }
}
