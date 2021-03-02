using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOGBook.Data
{
    public class Reply
    {
      
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public string Text { get; set; }
        [Required]
        public Guid ReplyAuthor { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        

    }
}
