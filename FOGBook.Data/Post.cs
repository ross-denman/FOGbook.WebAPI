using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOGBook.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [ForeignKey(nameof(Comment))]
        public int? CommentId { get; set; }

        [ForeignKey(nameof(Reply))]
        public int? ReplyId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid PostAuthor { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Reply Reply { get; set; }

    }
}
