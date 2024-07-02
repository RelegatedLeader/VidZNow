using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VidZNow.Data;
using VidZNow.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VidZNow.Pages
{
    public class CommentsModel : PageModel
    {
        private readonly AppDbContext _context;

        public CommentsModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Comment> Comments { get; set; }
        public Video Video { get; set; }
        [BindProperty]
        public Comment NewComment { get; set; }

        public async Task OnGetAsync(int videoId)
        {
            Video = await _context.Videos.FirstOrDefaultAsync(v => v.Id == videoId);

            Comments = await _context.Comments
                .Include(c => c.User)
                .Include(c => c.Video)
                .Include(c => c.Likes)
                .Where(c => c.VideoId == videoId)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int videoId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            NewComment.VideoId = videoId;
            NewComment.UserId = 1; // Assuming a logged-in user with ID 1 for simplicity

            _context.Comments.Add(NewComment);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { videoId });
        }
    }
}
