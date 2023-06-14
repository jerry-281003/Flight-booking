using FlightBooking5.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking5.Controllers
{
    public class Admin : Controller
    {
		private readonly FlightBooking5Context _context;

		public Admin(FlightBooking5Context context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View("Admin");
        }
        public async Task<IActionResult> AddFlight()
        {
			return _context.Flight != null ?
					   View(await _context.Flight.ToListAsync()) :
					   Problem("Entity set 'FlightBooking5Context.Flight'  is null.");
		}
    }
}
