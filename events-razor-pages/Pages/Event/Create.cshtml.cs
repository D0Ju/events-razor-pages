using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsRazorApp.Models;

namespace events_razor_pages.Pages_Event
{
    public class CreateModel : PageModel
    {
        private readonly EventDbContext _context;

        public CreateModel(EventDbContext context)
        {
            _context = context;
        }

        public SelectList VrstaList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            VrstaList = new SelectList(
                await _context.EventType.ToListAsync(),
                "Id",
                "Naziv"
            );
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Log validation errors for debugging
                Console.WriteLine("ModelState is invalid on POST to Create:");
                foreach (var kv in ModelState)
                {
                    if (kv.Value.Errors.Count > 0)
                    {
                        foreach (var err in kv.Value.Errors)
                        {
                            Console.WriteLine($"  {kv.Key}: {err.ErrorMessage}");
                        }
                    }
                }

                VrstaList = new SelectList(
                    await _context.EventType.ToListAsync(),
                    "Id",
                    "Naziv"
                );

                Console.WriteLine("Posted Event values:");
                try
                {
                    Console.WriteLine($"Naziv={Event?.Naziv}, Lokacija={Event?.Lokacija}, DatumPocetka={Event?.DatumPocetka}, DatumZavrsetka={Event?.DatumZavrsetka}, VrstaId={Event?.VrstaId}");
                }
                catch { }

                return Page();
            }

            Console.WriteLine("ModelState valid. Attempting to save Event:");
            Console.WriteLine($"Naziv={Event?.Naziv}, Lokacija={Event?.Lokacija}, DatumPocetka={Event?.DatumPocetka}, DatumZavrsetka={Event?.DatumZavrsetka}, VrstaId={Event?.VrstaId}");

            _context.Event.Add(Event);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SaveChanges failed: {ex.Message}");
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
