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
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                ReplyAuthor = _userId,
                Text = model.Text,
                CreatedUtc = DateTime.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyCreate> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.ReplyAuthor == _userId)
                    .Select(
                        e =>
                        new ReplyCreate
                        {
                            Text = e.Text
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
