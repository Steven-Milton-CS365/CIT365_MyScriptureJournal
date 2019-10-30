using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Journal
    {
        public int ID { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Reference { get; set; }

        [StringLength(1000, MinimumLength = 3)]
        [Required]
        public string Scripture { get; set; }

        [StringLength(3000, MinimumLength = 3)]
        [Required]
        public string Notes { get; set; }

        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
    }
}