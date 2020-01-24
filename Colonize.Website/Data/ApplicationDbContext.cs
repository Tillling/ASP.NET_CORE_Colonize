using Colonize.Website.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Colonize.Website.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet <Voyage> Voyage { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var ships = new List<Ship>
            {
                new Ship(1,
                "Moonshot",
                "A standard commercial Rocket for interplanetary travel",
                1000,
                new Uri("https://via.placeholder.com/1280x440png?text=moonshot", UriKind.Absolute)),

                new Ship(2,
                "Mars Rocket",
                "A Mars Rocket",
                2000,
                new Uri("https://via.placeholder.com/1280x440png?text=mars+rocket", UriKind.Absolute)),

            };

            var destinations = new List<Destination>
            {
                new Destination(1,
                "Moon",
                "Luna",
                new Uri("https://via.placeholder.com/1280x440png?text=Picture+of+the+moon", UriKind.Absolute)),

                new Destination(2,
                "Mars",
                "The Red Planet",
                new Uri("https://via.placeholder.com/1280x440png?text=planet", UriKind.Absolute)),

            };

            var moonshot = ships.Find(x => x.Name == "Moonshot");
            var marsRocket = ships.Find(x => x.Name == "Mars Rocket");
            var moon = destinations.Find(x => x.Name == "Moon");
            var mars = destinations.Find(x => x.Name == "Mars");

            var voyages = new List<Voyage>
            {
                new Voyage(1, moon.Id, moonshot.Id, new DateTime(2020, 06, 30), new DateTime(2020, 07, 15)),
                new Voyage(2, mars.Id, marsRocket.Id, new DateTime(2029, 02, 01), new DateTime(2029, 08, 20))
            };
            
            ships.ForEach(x => modelBuilder.Entity<Ship>().HasData(x));
            destinations.ForEach(x => modelBuilder.Entity<Destination>().HasData(x));
            voyages.ForEach(x => modelBuilder.Entity<Voyage>().HasData(x));
        }
    }
}
