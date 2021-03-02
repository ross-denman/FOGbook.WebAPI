using FOGbook.Data;
using FOGBook.Data;
using FOGBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOGBook.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                CommentAuthor = _userId,
                Text = model.Text,
                CreatedUtc = DateTime.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentCreate> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.CommentAuthor == _userId)
                    .Select(
                        e =>
                        new CommentCreate
                        {
                            CommentId = e.CommentId,
                            Text = e.Text,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
}
