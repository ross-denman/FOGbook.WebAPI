using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FOGbook.WebAPI.Controllers
{

    [Authorize]
    public class PostController : ApiController
    {
            public IHttpActionResult Get()
            {
                PostService noteService = CreatePostService();
                var posts = postService.GetPosts();
                return Ok(posts);
            }

            
            public IHttpActionResult Post(NoteCreate note)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateNoteService();

                if (!service.CreateNote(note))
                    return InternalServerError();

                return Ok();
            }


            private PostService CreatePostService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var postService = new PostService(userId);
                return postService;
            }

  }
}
