using Application.DTOs.FeedbackDTOs;
using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequiredAdminOrManager")]
    [Area("Admin")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ICustomerService _customerService;
        private readonly ITourService _tourService;
        private readonly IAccountService _accountService;
        public FeedbackController(IFeedbackService feedbackService, ICustomerService customerService, ITourService tourService, IAccountService accountService)
        {
            _feedbackService = feedbackService;
            _customerService = customerService;
            _tourService = tourService;
            _accountService = accountService;
        }

        // GET: /Feedback/
        [Authorize(Policy = "feedback-view")]
        public async Task<IActionResult> Index(Guid TourID)
        {
            // Lấy thông tin về tour từ dịch vụ
            var tour = await _tourService.GetByIdAsync(TourID);

            // Kiểm tra nếu không có tour, trả về NotFound
            if (tour == null)
            {
                return NotFound();
            }

            // Lấy danh sách phản hồi cho tour từ dịch vụ
            var feedbacks = await _feedbackService.GetByTourID(TourID);
            Console.WriteLine(feedbacks.Count());

            // Tạo danh sách FeedbackViewModel
            var feedbacksViewModel = new List<Application.DTOs.FeedbackDTOs.FeedbackViewModel>();

            // Duyệt qua từng phản hồi, lấy thông tin khách hàng liên quan
            foreach (var i in feedbacks)
            {
                var customer = await _customerService.GetById(i.CustomerID);

                // Tạo FeedbackViewModel với thông tin phản hồi và khách hàng
                var feedback = new Application.DTOs.FeedbackDTOs.FeedbackViewModel
                {
                    FeedbackID = i.FeedbackID,
                    CustomerID = i.CustomerID,
                    TourID = i.TourID,
                    Rating = i.Rating,
                    Comments = i.Comments,
                    CreateAt = i.CreateAt,
                    ModifyAt = i.ModifyAt,
                    Customer = customer // Gán thông tin khách hàng vào feedback
                };

                // Thêm feedback vào danh sách
                feedbacksViewModel.Add(feedback);
            }

            // Tạo TourFeedbackViewModel với thông tin tour và danh sách phản hồi
            var tourFeedbackViewModel = new TourFeedbackViewModel
            {
                TourID = TourID,
                TourName = tour.Title,  // Lấy tên tour
                Feedbacks = feedbacksViewModel, // Thêm danh sách phản hồi vào ViewModel
            };

            // Trả về view với TourFeedbackViewModel
            return View(tourFeedbackViewModel);
        }



        // GET: /Feedback/Create
        [Authorize(Policy = "feedback-add")]
        public async Task<IActionResult> Create(Guid TourID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);
            //var customerID = await _accountService.GetLoginUserId();


            var feedbackCreateViewModel = new FeedbackCreationDto
            {
                TourID = tour.TourID,
            };

            return View(feedbackCreateViewModel);
        }


        // POST: /Feedback/Create
        [HttpPost]
        [Authorize(Policy = "feedback-add")]
        public async Task<IActionResult> Create(Guid TourID, FeedbackCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _feedbackService.CreateAsync(dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = $"Thêm đánh giá cho Tour {dto.TourID} thành công";
                return RedirectToAction("Index", new { dto.TourID });
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Dữ liệu nhập không hợp lệ";
            return View(dto);
        }

        // GET: /Feedback/Update?{FeedbackID}
        [Authorize(Policy = "feedback-update")]
        [HttpGet]
        public async Task<IActionResult> Update(Guid TourID, Guid FeedbackID)
        {
            var feedback = await _feedbackService.GetById(FeedbackID);
            if (feedback != null)
            {
                var feedbackViewModel = new Application.DTOs.FeedbackDTOs.FeedbackUpdateDto
                {
                    FeedbackID = feedback.FeedbackID,
                    TourID = feedback.TourID,
                    Rating = feedback.Rating,
                    Comments = feedback.Comments,
                };
                return View(feedbackViewModel);
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không tìm thấy đánh giá id: {FeedbackID}";
            return RedirectToAction("Index", new { TourID = TourID });

        }

        // POST: /Feedback/Update?{FeedbackID}
        [HttpPost]
        [Authorize(Policy = "feedback-update")]
        public async Task<IActionResult> Update(Guid TourID, Guid FeedbackID, FeedbackUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _feedbackService.UpdateAsync(FeedbackID, dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = $"Cập nhật thông tin đánh giá thành công";
                return RedirectToAction("Index", new { TourID = TourID });

            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View(dto);
        }

        // POST: /Destination/Delete?{DestinationID}
        [Authorize(Policy = "destination-delete")]
        public async Task<IActionResult> Delete(Guid TourID,Guid FeedbackID)
        {
            await _feedbackService.DeleteAsync(FeedbackID);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành công!";
            TempData["NotificationMessage"] = "Xóa địa điểm thành công";
            return RedirectToAction("Index", new { TourID = TourID});
        }
    }
}