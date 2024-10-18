using Microsoft.AspNetCore.Mvc;
using Server.Models.Data;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    public readonly EFDataContext _db;

    public BookingController(EFDataContext db)
    {
        this._db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_db.Bookings);
    }
}
