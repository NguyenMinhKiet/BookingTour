using Application.DTOs.PaymentDTOs;
using Application.Services_Interface;
using Areas.Admin.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

namespace Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IBookingService _bookingService;
        public PaymentController(IPaymentService paymentService , IBookingService bookingService)
        {
            _paymentService = paymentService;
            _bookingService = bookingService;
        }

        // GET: /Payment/
        public async Task<IActionResult> Index()
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
        public async Task<IActionResult> CreateAsync(Guid BookingID)
        {
            return View();
        }

        // POST: /Payment/Create
        [HttpPost]
        public async Task<IActionResult> Create(PaymentCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _paymentService.CreateAsync(dto);

                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Thêm thanh toán thành công!";

                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View();
        }

        // GET: /Payment/Update?{payment_id}
        public async Task<IActionResult> Update(Guid PaymentID)
        {
            var payment = await _paymentService.GetById(PaymentID);
            if (payment == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy đánh giá id: {PaymentID}";
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
            if (ModelState.IsValid)
            {
                await _paymentService.UpdateAsync(PaymentID, dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin thanh toán thành công!";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Cập nhật thông tin thanh toán thất bại";
            return View();
        }

        // POST: /Payment/Delete?{PaymentID}
        public async Task<IActionResult> Delete(Guid PaymentID)
        {
            await _paymentService.DeleteAsync(PaymentID);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành Công!";
            TempData["NotificationMessage"] = "Xóa thông tin thanh toán thành công!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> checkStatus(Guid BookingID)
        {
            var payment = await _paymentService.GetByBookingId(BookingID);
            var status = await _paymentService.GetStatus(BookingID);
            if (status)
            {
                return await hasNoPay(payment.PaymentID);
            }
            return await hasPayed(payment.PaymentID);
        }

        [HttpPost]
        public async Task<IActionResult> hasNoPay(Guid PaymentID)
        {
            var status = false;
            await _paymentService.ChangeStatus(PaymentID, status);
            ViewData["Status"] = status.ToString().ToLower();
            TempData["NotificationType"] = "warning";
            TempData["NotificationTitle"] = "Thành Công!";
            TempData["NotificationMessage"] = "Thay đổi trạng thái thanh toán thành công!";
            return RedirectToAction("Index","Booking");
        }

        [HttpPost]
        public async Task<IActionResult> hasPayed(Guid PaymentID)
        {
            var status = true;
            await _paymentService.ChangeStatus(PaymentID, status);
            ViewData["Status"] = status.ToString().ToLower();
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành Công!";
            TempData["NotificationMessage"] = "Thay đổi trạng thái thanh toán thành công!";
            return RedirectToAction("Index", "Booking");
        }

        
    }
}