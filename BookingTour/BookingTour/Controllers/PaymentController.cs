using Application.DTOs.PaymentDTOs;
using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IBookingService _bookingService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: /Payment/
        public async Task<IActionResult>  Index()
        {
            var payments = await _paymentService.GetAllAsync();
            var paymentsViewModel = payments.Select(i => new PaymentViewModel
            {
                PaymentID = i.PaymentID,
                BookingID = i.BookingID,
                CreateAt = i.CreateAt,
                Method = i.Method,
                Status = i.Status
            }).ToList();

            return View(paymentsViewModel);
        }

        // GET: /Payment/Create
        public  async Task<IActionResult> CreateAsync()
        {
            var bookings = await _bookingService.GetAllAsync();
            var bookingsViewModel = bookings.Select(i => new BookingViewModel
            {
                BookingID = i.BookingID,

            }).ToList();
            var bookingsSelectList = new SelectList(bookingsViewModel, "BookingID", "BookingID");

            ViewBag.TourList = bookingsSelectList;

            return View();
        }

        // POST: /Payment/Create
        [HttpPost]
        public async Task<IActionResult> Create(PaymentCreationDto dto)
        {
            if(ModelState.IsValid)
            {
                await _paymentService.CreateAsync(dto);
                TempData["success"] = "Thêm thông tin thanh toán mới thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm thông tin thanh toán mới thất bại.";
            return View();
        }

        // GET: /Payment/Update?{payment_id}
        public async Task<IActionResult> Update(Guid PaymentID)
        {
            var payment = await _paymentService.GetById(PaymentID);
            if(payment == null)
            {
                TempData["error"] = "Không tìm thấy thông tin thanh toán " + PaymentID;
                return RedirectToAction("Index");
            }

            var paymentViewModel = new PaymentViewModel
            {
                PaymentID = payment.PaymentID,
                BookingID = payment.BookingID,
                Method = payment.Method,
                Status = payment.Status,
                CreateAt = payment.CreateAt,
                ModifyAt = payment.ModifyAt
            };

            return View(paymentViewModel);
        }

        // POST: /Payment/Update?{PaymentID}
        [HttpPost]
        public async Task<IActionResult> Update(Guid PaymentID, PaymentUpdateDto dto)
        {
            if(ModelState.IsValid)
            {
                await _paymentService.UpdateAsync(PaymentID, dto);
                TempData["success"] = "Cập nhật thông tin thanh toán thành công !!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Cập nhật thông tin thanh toán thất bại !!";
            return View();
        }

        // POST: /Payment/Delete?{PaymentID}
        public async Task<IActionResult> Delete(Guid PaymentID)
        {
            await _paymentService.DeleteAsync(PaymentID);
            TempData["success"] = "Xóa địa điểm " + PaymentID + " thành công.";
            return RedirectToAction("Index");
        }
    }
}
