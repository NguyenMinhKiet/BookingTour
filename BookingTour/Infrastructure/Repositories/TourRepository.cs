using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;
        public static int PAGE_SIZE { get; set; } = 6;
        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tour = await GetByIdAsync(id);
            if (tour == null)
            {
                throw new Exception($"Tour with id {id} not found.");
            }
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
        }

        

        public async Task<IEnumerable<Tour>> GetAllAsync()
        {
            return await _context.Tours.ToListAsync();
        }

        public async Task<Tour> GetByIdAsync(Guid tour_id)
        {
            return await _context.Tours.FindAsync(tour_id);
        }

        public async Task<List<TourDestination>> GetDestinations(Guid tourID)
        {
            // Lấy danh sách TourDestination liên quan đến TourID
            var tourDestinations = await _context.ToursDestination
                .Where(x => x.TourID == tourID)
                .Include(td => td.Destination) // Bao gồm đối tượng Destination
                .ToListAsync();

            return tourDestinations;
        }


        public async Task<List<TourEmployee>> GetEmployees(Guid tourID)
        {
            // Lấy danh sách TourDestination liên quan đến TourID
            var tourEmployees = await _context.ToursEmployee
                .Where(x => x.TourID == tourID)
                .Include(td => td.Employee) // Bao gồm đối tượng Destination
                .ToListAsync();

            return tourEmployees;
        }

        public async Task<IEnumerable<Tour>> GetToursByCategories(List<string> categories)
        {
            if (categories == null || categories.Count < 0)
            {
                // Trả về toàn bộ tour nếu không có danh mục nào được chọn
                return await _context.Tours.ToListAsync();
            }

            // Lọc tour dựa trên danh mục
            return await _context.Tours
                                 .Where(tour => categories.Contains(tour.Category))
                                 .ToListAsync();
        }

        public async Task UpdateAsync(Tour tour)
        {
            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tour>> GetAll(string search, decimal? from, decimal? to, string? sortBy)
        {
            var tours = _context.Tours.AsQueryable();
            #region Filtering
            if (!string.IsNullOrWhiteSpace(search))
            {
                tours = tours.Where(x => EF.Functions.Like(x.Title, $"%{search}%"));
            }
            if (from.HasValue)
            {
                tours = tours.Where(x => x.Price >= from);
            }
            if (to.HasValue)
            {

                tours = tours.Where(x => x.Price <= to);
            }
            #endregion

            #region Sorting

            tours = tours.OrderBy(x => x.Title);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "title_desc":
                        tours = tours.OrderByDescending(x => x.Title);
                        break;

                    case "price_asc":
                        tours = tours.OrderBy(x => x.Price);
                        break;

                    case "price_dsc":
                        tours = tours.OrderByDescending(x => x.Price);
                        break;
                }
            }
            #endregion

            //#region Paging
            //var totalProducts = tours.Count();

            //tours = tours.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var totalPages = (int)Math.Ceiling((double)totalProducts / PAGE_SIZE);
            //var tourServiceModel = new TourServiceViewModel
            //{
            //    ItemCount = totalProducts,
            //    PageNumber = page,
            //    Tours = tours.Select(x => new TourViewModel
            //    {
            //        TourID = x.TourID,
            //        Title = x.Title,
            //        Description = x.Description,
            //        Price = x.Price,
            //        StartDate = x.StartDate,
            //        EndDate = x.EndDate,
            //        Category = x.Category,
            //        City = x.City
            //    }).ToList()
            //};

            return tours.ToList();

        }

        public async Task<List<Tour>> GetAllByName(string name)
        {
            return await _context.Tours.Where(x=>x.Title.ToLower() == name.ToLower())
                .ToListAsync();
        }
        public async Task<List<Tour>> GetAllWithOut(string category)
        {
            return await _context.Tours.Where(x => x.Category == category)
                .ToListAsync();
        }

        public async Task<List<TourHotel>> GetHotels(Guid TourID)
        {
            return await _context.TourHotels.Where(x => x.TourID == TourID)
                .Include(td => td.Hotel).ToListAsync();
        }
    }
}
