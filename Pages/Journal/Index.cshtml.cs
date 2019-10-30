using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Journal
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Models.Journal> Journal { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookSelect { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of books.
            IQueryable<string> bookQuery = from b in _context.Journal
                orderby b.Book
                select b.Book;

            var notes = from n in _context.Journal
                select n;
            if (!string.IsNullOrEmpty(SearchString))
            {
                notes = notes.Where(s => s.Notes.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(BookSelect))
            {
                notes = notes.Where(x => x.Book == BookSelect);
            }
            Book = new SelectList(await bookQuery.Distinct().ToListAsync());
            Journal = await notes.ToListAsync();
        }
    }
}
