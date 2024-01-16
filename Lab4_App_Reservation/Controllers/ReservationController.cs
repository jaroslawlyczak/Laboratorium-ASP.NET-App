using Lab4_App_Reservation.Models.ReservationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Lab4_App_Reservation.Controllers
{
    [Authorize(Roles = "admin")]

    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder)
        {
            var reservations = await _reservationService.FindAllAsync();

            reservations = SortReservations(reservations, sortOrder);

            ViewBag.CurrentSort = sortOrder;

            return View(reservations);
        }
        private List<Reservation> SortReservations(List<Reservation> reservations, string sortOrder)
        {
            switch (sortOrder)
            {
                case "ContactId_asc":
                    reservations = reservations.OrderBy(r => r.ContactName).ToList();
                    break;
                case "ContactId_desc":
                    reservations = reservations.OrderByDescending(r => r.ContactName).ToList();
                    break;
                case "Miasto_asc":
                    reservations = reservations.OrderBy(r => r.Miasto).ToList();
                    break;
                case "Miasto_desc":
                    reservations = reservations.OrderByDescending(r => r.Miasto).ToList();
                    break;
                case "Data_asc":
                    reservations = reservations.OrderBy(r => r.Data).ToList();
                    break;
                case "Data_desc":
                    reservations = reservations.OrderByDescending(r => r.Data).ToList();
                    break;
                default:
                    reservations = reservations.OrderBy(r => r.ContactId).ToList();
                    break;
            }

            return reservations;
        }

        [HttpGet]
        public async Task<IActionResult> SearchIndexApi(string? search = null)
        {
            try
            {
                List<Reservation> reservations;

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7149/");
                    var response = await httpClient.GetAsync($"api/reservations?q={search}");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        reservations = JsonConvert.DeserializeObject<List<Reservation>>(content);
                    }
                    else
                    {
                        reservations = new List<Reservation>();
                    }
                }

                ViewBag.SearchTerm = !string.IsNullOrEmpty(search) ? search : null;

                return View(reservations);
            }
            catch (Exception)
            {
                ViewBag.SearchTerm = null;
                return View(new List<Reservation>());
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> PagedIndex(int page = 1, int size = 5)
        {
            if (size < 1)
            {
                return BadRequest();
            }
            return View(await _reservationService.FindPageAsync(page, size));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var contacts = CreateContactItemList();
            var model = new Reservation { ContactList = contacts };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation model)
        {
            if (ModelState.IsValid)
            {
                await _reservationService.AddAsync(model);
                return RedirectToAction("Index");
            }
            model.ContactList = CreateContactItemList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _reservationService.FindByIdAsync(id);
            model.ContactList = CreateContactItemList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Reservation model)
        {
            if (ModelState.IsValid)
            {
                await _reservationService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            model.ContactList = CreateContactItemList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _reservationService.FindByIdAsync(id);
            model.ContactList = CreateContactItemList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Reservation model)
        {
            await _reservationService.DeleteByIdAsync(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _reservationService.FindByIdAsync(id));
        }

        private List<SelectListItem> CreateContactItemList()
        {
            var group = new SelectListGroup { Name = "Kontakty" };
            return _reservationService.FindAllContactsAsync()
                .Result
                .Select(e => new SelectListItem { Text = e.Name, Value = e.ContactId.ToString(), Group = group })
                .ToList();
        }

    }
}
