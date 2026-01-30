using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventsRazorApp.Models;

    public class EventDbContext : DbContext
    {
        public EventDbContext (DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventsRazorApp.Models.Event> Event { get; set; } = default!;
    }
