using Application.DTOs.FeedbackDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class FeedbackController : Controller
    {
        private IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // GET: /Feedback/
        public async Task<IActionResult> Index()
        {
            var feedbacks = await _feedbackService.GetAllAsync();
            var feedbacksViewModel = feedbacks.Select(i => new FeedbackViewModel
            {
                customer_id = i.customer_id,
                tour_id = i.tour_id,
                rating = i.rating,
                comments = i.comments,
            }).ToList();
            return View(feedbacksViewModel);
        }


        // GET: /Feedback/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: /Feedback/Create
        public async Task<IActionResult> Create(FeedbackCreationDto dto)
        {
            if(ModelState.IsValid)
            {
                await _feedbackService.CreateAsync(dto);
                TempData["success"] = "Thêm đánh giá mới thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm đánh giá mới thất bại !!";
            return View();
        }

        // GET: /Feedback/Update?{feedback_id}
        public async Task<IActionResult> Update(int feedback_id)
        {
            var feedback = await _feedbackService.GetById(feedback_id);
            if(feedback != null)
            {
                var feedbackViewModel = new FeedbackViewModel
                {
                    customer_id = feedback.customer_id,
                    tour_id = feedback.tour_id,
                    rating = feedback.rating,
                    comments = feedback.comments,
                };
                return View(feedbackViewModel);
            }
            return RedirectToAction("Error", "Shared");
        }

        // POST: /Feedback/Update?{feedback_id}
        public async Task<IActionResult> Update(int feedback_id, FeedbackUpdateDto dto)
        {
            if(ModelState.IsValid)
            {
                await _feedbackService.UpdateAsync(feedback_id, dto);
                TempData["success"] = "Thay đổi thông tin khách hàng " + feedback_id + " thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Không tìm thấy khách hàng !!";
            return View();
        }
    }
}
