using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsRazorApp.Models;

namespace events_razor_pages.Pages_EventType
{
    public class IndexModel : PageModel
    {
        private readonly EventDbContext _context;

        public IndexModel(EventDbContext context)
        {
            _context = context;
        }

        public IList<EventType> EventType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            EventType = await _context.EventType.ToListAsync();
        }
    }
}
