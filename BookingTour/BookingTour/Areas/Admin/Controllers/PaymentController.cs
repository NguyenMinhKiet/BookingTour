using Application.DTOs.PaymentDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequiredAdminOrManager")]
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
        [Authorize(Policy = "payment-view")]
        public async Task<IActionResult> Index()
        {
            var payments = await _paymentService.GetAllAsync();
            var paymentsViewModel = payments.Select(i => new PaymentViewModel
            {
                PaymentID = i.PaymentID,
                BookingID = i.BookingID,
                CreateAt = i.CreateAt,
                Total = i.Total,
                Method = i.Method,
                Status = i.Status
            }).ToList();
            ViewData["ActivePage"] = "TourManager";
            return View(paymentsViewModel);
        }

        // GET: /Payment/Create
        [Authorize(Policy = "payment-add")]
        public IActionResult CreateAsync(Guid BookingID)
        {
            ViewData["ActivePage"] = "TourManager";
            return View();
        }

        // POST: /Payment/Create
        [HttpPost]
        [Authorize(Policy = "payment-add")]
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
            return View(dto);
        }

        // GET: /Payment/Update?{payment_id}
        [Authorize(Policy = "payment-update")]
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

            var paymentViewModel = new PaymentUpdateDto
            {
                PaymentID = payment.PaymentID,
                BookingID = payment.BookingID,
                Method = payment.Method,
                Status = payment.Status,
                Total = payment.Total,
                CreateAt = payment.CreateAt,
                ModifyAt = payment.ModifyAt
            };
            ViewData["ActivePage"] = "TourManager";
            return View(paymentViewModel);
        }

        // POST: /Payment/Update?{PaymentID}
        [HttpPost]
        [Authorize(Policy = "payment-update")]
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
        [Authorize(Policy = "payment-delete")]
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