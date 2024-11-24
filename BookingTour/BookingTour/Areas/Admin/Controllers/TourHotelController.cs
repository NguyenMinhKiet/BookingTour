using Application.DTOs.HotelDto;
using Application.DTOs.TourHotelDto;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy ="RequiredAdminOrManager")]
    public class TourHotelController : Controller
    {
        private readonly ITourHotelService _tourHotelService;
        private readonly ITourService _tourService;
        private readonly IHotelService _hotelService;
        public TourHotelController(ITourHotelService tourHotelService, ITourService tourSerice, IHotelService hotelService)
        {
            _tourHotelService = tourHotelService;
            _tourService = tourSerice;
            _hotelService = hotelService;
        }

        public async Task<IActionResult> Index(Guid TourID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);
            if(tour != null)
            {
                var tourHotels = await _tourHotelService.GetByTourID(TourID);
                var hotelWithDates = new List<HotelWithDateDto>();
                if (tourHotels != null)
                {
                    hotelWithDates = (await Task.WhenAll(tourHotels.Select(async x =>
                    {
                        var hotelModel = await _hotelService.GetByIdAsync(x.HotelID);
                        return new HotelWithDateDto
                        {
                            hotel = new HotelModel
                            {
                                HotelID = hotelModel.HotelID,
                                Name = hotelModel.Name,
                                StarRating = hotelModel.StarRating,
                                Description = hotelModel.Description,
                                Address = hotelModel.Address,
                                SelectedCity = hotelModel.City,
                                SelectedDistrict = hotelModel.District,
                                SelectedWard = hotelModel.Ward
                            },
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                        };
                    }))).ToList();
                }


                var model = new TourHotelModel
                {
                    TourID = tour.TourID,
                    Tour = tour,
                    Hotels = hotelWithDates
                };
                return View(model);
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không tìm thấy TourID: {TourID}!";
            return RedirectToAction("Index", "Tour", new { TourID });
        }
        public async Task<IActionResult> Create(Guid TourID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);
            var hotels = await _hotelService.GetAllAsync(tour.City);
            var hotelList = hotels.Select(x => new HotelModel
            {
                HotelID = x.HotelID,
                Name = x.Name,
                StarRating = x.StarRating,
                Address = x.Address,
                SelectedCity = x.City,
                SelectedDistrict = x.District,
                SelectedWard = x.Ward,
            }).ToList();

            ViewBag.Hotels = hotelList;

            var model = new TourHotelCreationDto
            {
                TourID = TourID,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TourHotelCreationDto model)
        {
            if (ModelState.IsValid)
            {
                var tourhotelModel = new TourHotelDto
                {
                    TourID = model.TourID,
                    Tour = await _tourService.GetByIdAsync(model.TourID),
                    HotelID = model.HotelID,
                    Hotel = await _hotelService.GetByIdAsync(model.HotelID),
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                };
                await _tourHotelService.CreateAsync(tourhotelModel);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = $"Thêm khách sạn {tourhotelModel.Hotel.Name} vào tour {tourhotelModel.Tour.Title} thành công!";
                return RedirectToAction("Index", "Tour");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Thêm khách sạn thất bại!";


            var tour = await _tourService.GetByIdAsync(model.TourID);
            var hotels = await _hotelService.GetAllAsync(tour.City);

            var hotelList = hotels.Select(x => new HotelModel
            {
                HotelID = x.HotelID,
                Name = x.Name,
                StarRating = x.StarRating,
                Address = x.Address,
                SelectedCity = x.City,
                SelectedDistrict = x.District,
                SelectedWard = x.Ward,
            }).ToList();

            ViewBag.Hotels = hotelList;
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid TourID, Guid HotelID)
        {
            var tourHotel = await _tourHotelService.GetById(TourID, HotelID);
            if(tourHotel != null)
            {
                await _tourHotelService.DeleteAsync(TourID, HotelID);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = $"Xóa khách sạn trong tour thành công!";
                return RedirectToAction("Index", "Tour");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Xóa khách sạn thất bại!";
            return RedirectToAction("Index", "Tour");
        }
    }
}
