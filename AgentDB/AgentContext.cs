using AgentApp.Models;
using AgentDB.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AgentDB
{
    public class AgentContext : DbContext
    {
        public AgentContext(DbContextOptions options) : base(options) { }

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<AccommodationType> AccommodationTypes { get; set; }
        public DbSet<AdditionalService> AdditionalServices { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PeriodPrice> PeriodPrices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationRating> ReservationRatings { get; set; }
        public DbSet<Unavailability> Unavailabilities { get; set; }
        public DbSet<AdditionalServicesOnly> AdditionalServicesOnlies { get; set; }

    }
}
