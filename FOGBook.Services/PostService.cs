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
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)  
        {
            Post entity = new Post()
            {

                PostAuthor = _userId,

                Title = model.Title,
                Text = model.Text,
                CreatedUtc = DateTime.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ListPost> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts
                            .Where(e => e.PostAuthor == _userId)
                            .Select(e =>
                                new ListPost
                                {
                                    PostId = e.PostId,
                                    Title = e.Title,
                                    Text = e.Text,
                                    CreatedUtc = e.CreatedUtc
                                });
                return query.ToArray();
            }
        }
        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId && e.PostAuthor == _userId);
                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
