using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOGBook.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey(nameof(Reply))]
        public int? ReplyId { get; set; }

        [Required]
        public string Text { get; set; }
        
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [Required]
        public Guid CommentAuthor { get; set; }

        public virtual Reply Reply { get; set; }

    }
}
