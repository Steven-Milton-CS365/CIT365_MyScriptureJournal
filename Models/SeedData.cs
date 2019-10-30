using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Journal.Any())
                {
                    return;   // DB has been seeded
                }

                context.Journal.AddRange(
                    new Journal
                    {
                        Book = "Book of Mormon",
                        EntryDate = DateTime.Now,
                        Reference = "1 Nephi 3:7",
                        Scripture = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.",
                        Notes = "I will go and do"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}