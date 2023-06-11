using FlightBooking5.Data;
using FlightBooking5.Infrastructure;
using FlightBooking5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace FlightBooking5.Controllers
{
    public class CartController : Controller
    {
        public Cart? Cart { get; set; }
        private readonly FlightBooking5Context _context;
        public CartController(FlightBooking5Context context)
        {
            _context = context;
        }
        public IActionResult AddToCart(int flightId)
        {
            Flight? flight = _context.Flight
            .FirstOrDefault(f => f.flightId == flightId);
            if (flight != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(flight, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }

            return View("cart",Cart);
        }
        public IActionResult RemoveFromCart(int flightId)
        {
            Flight? flight = _context.Flight
            .FirstOrDefault(f => f.flightId == flightId);
            if (flight != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.RemoveLine(flight);
                HttpContext.Session.SetJson("cart", Cart);
            }

            return View("cart", Cart);
        }
    }
}
