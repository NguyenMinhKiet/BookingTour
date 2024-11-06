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
                payment_id = i.payment_id,
                booking_id = i.booking_id,
                payment_date = i.payment_date,
                payment_method = i.payment_method,
                payment_status = i.payment_status
            }).ToList();

            return View(paymentsViewModel);
        }

        // GET: /Payment/Create
        public  async Task<IActionResult> CreateAsync()
        {
            var bookings = await _bookingService.GetAllAsync();
            var bookingsViewModel = bookings.Select(i => new BookingViewModel
            {
                booking_id = i.booking_id,

            }).ToList();
            var bookingsSelectList = new SelectList(bookingsViewModel, "booking_id", "booking_id");

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
        public async Task<IActionResult> Update(int payment_id)
        {
            var payment = await _paymentService.GetById(payment_id);
            if(payment == null)
            {
                TempData["error"] = "Không tìm thấy thông tin thanh toán " + payment_id;
                return RedirectToAction("Index");
            }

            var paymentViewModel = new PaymentViewModel
            {
                booking_id = payment.booking_id,
                payment_date = payment.payment_date,
                payment_method = payment.payment_method,
                payment_status = payment.payment_status
            };

            return View(paymentViewModel);
        }

        // POST: /Payment/Update?{payment_id}
        [HttpPost]
        public async Task<IActionResult> Update(int payment_id, PaymentUpdateDto dto)
        {
            if(ModelState.IsValid)
            {
                await _paymentService.UpdateAsync(payment_id, dto);
                TempData["success"] = "Cập nhật thông tin thanh toán thành công !!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Cập nhật thông tin thanh toán thất bại !!";
            return View();
        }

        // POST: /Payment/Delete?{payment_id}
        public async Task<IActionResult> Delete(int payment_id)
        {
            await _paymentService.DeleteAsync(payment_id);
            TempData["success"] = "Xóa địa điểm " + payment_id + " thành công.";
            return RedirectToAction("Index");
        }
    }
}
