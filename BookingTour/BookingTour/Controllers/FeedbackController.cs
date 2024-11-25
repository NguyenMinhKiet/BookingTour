using Application.DTOs.FeedbackDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
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
        public async Task<IActionResult> Index(Guid TourID, Guid CustomerID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);
            if (tour == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy Tou";
                return RedirectToAction("History", "Booking");
            }
            var feedbacks = await _feedbackService.GetByTourIDAndCustomerID(TourID, CustomerID);
            if (feedbacks == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy feedback nào";
                return RedirectToAction("History", "Booking");
            }
            // Tạo danh sách FeedbackViewModel
            var feedbacksViewModel = feedbacks.Select(i=> new FeedbackViewModel
            {
                    FeedbackID = i.FeedbackID,
                    CustomerID = i.CustomerID,
                    TourID = i.TourID,
                    Rating = i.Rating,
                    Comments = i.Comments,
                    CreateAt = i.CreateAt,
                    ModifyAt = i.ModifyAt,
                    Customer = i.Customer,
                    Tour = i.Tour,
            }).ToList();

            var tourFeedbackModel = new TourFeedbackViewModel
            {
                TourID = tour.TourID,
                TourName = tour.Title,
                CustomerID = CustomerID,
                Feedbacks = feedbacksViewModel
            };
            // Trả về view với TourFeedbackViewModel
            return View(tourFeedbackModel);
        }



        // GET: /Feedback/Create
        [Authorize(Policy = "feedback-add")]
        public async Task<IActionResult> Create(Guid TourID)
        {
            var customerID =  HttpContext.Session.GetString("UserID");
            if (customerID == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Có vẻ bạn chưa đăng nhập!";
                return RedirectToAction("Login", "Account");
            }

            var tour = await _tourService.GetByIdAsync(TourID);


            var feedbackCreateViewModel = new FeedbackCreationDto
            {
                TourID = tour.TourID,
                CustomerID = Guid.Parse(customerID),
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
                TempData["NotificationMessage"] = $"Thêm đánh giá cho Tour thành công";
                return RedirectToAction("Detail", "Tour" ,new { dto.TourID });
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Dữ liệu nhập không hợp lệ";
            return View(dto);
        }

        // GET: /Feedback/Update?{FeedbackID}
        [Authorize(Policy = "feedback-update")]
        [HttpGet]
        public async Task<IActionResult> Update(Guid TourID, Guid FeedbackID, Guid CustomerID)
        {
            var feedback = await _feedbackService.GetById(FeedbackID);
            if (feedback != null)
            {
                var feedbackViewModel = new FeedbackUpdateDto
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
            return RedirectToAction("Index", new { TourID, CustomerID });

        }

        // POST: /Feedback/Update?{FeedbackID}
        [HttpPost]
        [Authorize(Policy = "feedback-update")]
        public async Task<IActionResult> Update(Guid TourID, Guid FeedbackID, Guid CustomerID,FeedbackUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _feedbackService.UpdateAsync(FeedbackID, dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = $"Cập nhật thông tin đánh giá thành công";
                return RedirectToAction("Index", new { TourID, CustomerID });

            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View(dto);
        }

        // POST: /Destination/Delete?{DestinationID}
        [Authorize(Policy = "destination-delete")]
        public async Task<IActionResult> Delete(Guid TourID, Guid FeedbackID, Guid CustomerID)
        {
            await _feedbackService.DeleteAsync(FeedbackID);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành công!";
            TempData["NotificationMessage"] = "Xóa địa điểm thành công";
            return RedirectToAction("Index", new { TourID , CustomerID});
        }
    }
}