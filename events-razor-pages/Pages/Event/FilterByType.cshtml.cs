using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsRazorApp.Models;

namespace events_razor_pages.Pages_Event
{
    public class FilterByTypeModel : PageModel
    {
        private readonly EventDbContext _context;

        public FilterByTypeModel(EventDbContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get; set; }
        public string VrstaName { get; set; }

        public async Task<IActionResult> OnGetAsync(int vrstaId)
        {
            var vrsta = await _context.EventType.FirstOrDefaultAsync(v => v.Id == vrstaId);
            if (vrsta == null)
            {
                return NotFound();
            }

            VrstaName = vrsta.Naziv;
            Events = await _context.Event
                .Where(e => e.VrstaId == vrstaId && e.Aktivan)
                .OrderByDescending(e => e.DatumPocetka)
                .ToListAsync();

            return Page();
        }
    }
}
