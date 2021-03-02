using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOGBook.Models
{
    public class ListPost
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
