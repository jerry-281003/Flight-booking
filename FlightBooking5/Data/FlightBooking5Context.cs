﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking5.Data
{
    public class FlightBooking5Context : IdentityDbContext
    {
        public FlightBooking5Context(DbContextOptions<FlightBooking5Context> options)
            : base(options)
        {
        }

        public DbSet<FlightBooking5.Models.Customer> Customer { get; set; } = default!;

        public DbSet<FlightBooking5.Models.Flight>? Flight { get; set; }
    }
}
