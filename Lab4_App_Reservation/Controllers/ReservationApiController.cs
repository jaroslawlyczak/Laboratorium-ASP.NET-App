using Data;
using Lab4_App_Reservation.Models.ReservationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_App_Reservation.Controllers;


[Route("api/reservations")]
[ApiController]
public class ReservationApiController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationApiController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetReservationsByName(string? q)
    {
        try
        {
            var reservations = await _reservationService.FindAllAsync();

            if (!string.IsNullOrEmpty(q))
            {
                reservations = reservations
                    .Where(r => r.ContactName.Contains(q, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(reservations);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}