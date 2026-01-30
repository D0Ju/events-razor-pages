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
    public class DetailsModel : PageModel
    {
        private readonly EventDbContext _context;

        public DetailsModel(EventDbContext context)
        {
            _context = context;
        }

        public EventType EventType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventtype = await _context.EventType.FirstOrDefaultAsync(m => m.Id == id);

            if (eventtype is not null)
            {
                EventType = eventtype;

                return Page();
            }

            return NotFound();
        }
    }
}
