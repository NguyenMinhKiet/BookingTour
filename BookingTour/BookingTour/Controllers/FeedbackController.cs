using Application.DTOs.FeedbackDTOs;
using Application.Services_Interface;
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
                feedback_id = i.feedback_id,
                customer_id = i.customer_id,
                tour_id = i.tour_id,
                rating = i.rating,
                comments = i.comments,
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
                customer_id = i.customer_id,
                full_name = i.last_name +" "+ i.first_name
            }).ToList();

            // Tạo SelectList cho dropdown khách hàng
            var customersSelectList = new SelectList(customersViewModel, "customer_id", "full_name");

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
                    feedback_id = feedback.feedback_id,
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
        [HttpPost]
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
