using FlightBooking5.Data;
using FlightBooking5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FlightBooking5.Controllers
{
    public class Admin : Controller
    {
		private readonly FlightBooking5Context _context;
		private readonly RoleManager<IdentityRole> _roleManager;

		public Admin(FlightBooking5Context context,RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_roleManager = roleManager;
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
        public async Task<IActionResult> AddRole()
        {
			var roles = _roleManager.Roles;
			
			return View("AddRole",roles);
        }
        public async Task<IActionResult> PaymentDetails()
        {
			List<PaymentDetails> paymentDetails = await _context.PaymentDetails.ToListAsync();			
			return View("PaymentDetails", paymentDetails);
        }
    }
}
