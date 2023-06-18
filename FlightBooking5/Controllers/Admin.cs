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
		private readonly UserManager<IdentityUser> _userManager;

		public Admin(FlightBooking5Context context,RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_roleManager = roleManager;
			_userManager = userManager;
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
        public async Task<IActionResult> EmployeeAssignment()
        {
            return _context.Employee != null ?
                         View(await _context.Employee.ToListAsync()) :
                         Problem("Entity set 'FlightBooking5Context.Employee'  is null.");
        }
		[Authorize(Roles = "Employee")]
		public async Task<IActionResult> EmployeeSchedule()
			 
		
		{
			string userName = User.Identity.Name;

			var user = _userManager.FindByNameAsync(userName).Result;

			if (user != null)
			{
				bool isEmployee = _userManager.IsInRoleAsync(user, "Employee").Result;

				if (isEmployee)
				{
					var employee = _context.Employee.FirstOrDefault(e => e.Name == user.UserName);

					if (employee != null)
					{
						var schedule = _context.Flight
							.Where(f => f.flightId.ToString() == employee.flightId)
							.FirstOrDefault();

						if (schedule != null)
						{
							// Return the view to display the flight information
							return View(schedule);
						}
					}
				}
			}

			// Return a view to display a message if the schedule is not found or the user doesn't have the "Employee" role
			return View("NotFound");
		}

	}
    
}
