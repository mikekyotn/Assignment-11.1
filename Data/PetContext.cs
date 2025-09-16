using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_11._1.Models;

namespace Assignment_11._1.Data
{
    public class PetContext : DbContext
    {
        public DbSet<Pet> PetList { get; set; }
        public DbSet<PetEvent> EventList { get; set; }

        //Constructor - automatically called by dependency injection
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
            
            Database.EnsureCreated(); //ensure dB is created
        }
        //dataseeding OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasData(
                new Pet { PetId = 1, PetName = "Cookie", PetType = "Dog", PetBreed = "Teacup Poodle" },
                new Pet { PetId = 2, PetName = "Mocha", PetType = "Dog", PetBreed = "Chihuahua/Poodle" }
                );
            modelBuilder.Entity<PetEvent>().HasData(
                new PetEvent { EventId = 1, EventDate = new DateOnly(2025,05,05), EventType = "Routine", EventDescription = "Ate only once today", EventComments = "Keep Checking", PetId = 2},
                new PetEvent { EventId = 2, EventDate = new DateOnly(2025,05,05), EventType = "Routine", EventDescription = "Didn't want to walk today", EventComments = "None", PetId = 1},
                new PetEvent { EventId = 3, EventDate = new DateOnly(2025, 05, 06), EventType = "Appointment", EventDescription = "Rabies shot only", EventComments = "Good girl", PetId = 2 },
                new PetEvent { EventId = 4, EventDate = new DateOnly(2025, 05, 06), EventType = "Appointment", EventDescription = "Rabies and Bordatella shots", EventComments = "Good Boy", PetId = 1 },
                new PetEvent { EventId = 5, EventDate = new DateOnly(2025, 05, 07), EventType = "Routine", EventDescription = "Ate a baby rabbit and threw up", EventComments = "Bad girl", PetId = 2 },
                new PetEvent { EventId = 6, EventDate = new DateOnly(2025, 05, 07), EventType = "Routine", EventDescription = "Slept a lot, no walkies", EventComments = "Possible effects of shots", PetId = 1 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
