using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsRazorApp.Models;

namespace events_razor_pages.Pages_Event
{
    public class SortedByDateModel : PageModel
    {
        private readonly EventDbContext _context;

        public SortedByDateModel(EventDbContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get; set; }
        public string SortOrder { get; set; }

        public async Task OnGetAsync(string sortOrder = "asc")
        {
            SortOrder = sortOrder;

            var events = _context.Event
                .Where(e => e.Aktivan)
                .AsQueryable();

            if (sortOrder == "desc")
            {
                Events = await events
                    .OrderByDescending(e => e.DatumPocetka)
                    .ToListAsync();
            }
            else
            {
                Events = await events
                    .OrderBy(e => e.DatumPocetka)
                    .ToListAsync();
            }
        }
    }
}
