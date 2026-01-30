using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsRazorApp.Models;

namespace events_razor_pages.Pages_Event
{
    public class DetailsModel : PageModel
    {
        private readonly EventDbContext _context;

        public DetailsModel(EventDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ev = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);

            if (ev is not null)
            {
                Event = ev;

                return Page();
            }

            return NotFound();
        }
    }
}
