using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VidZNow.Data;
using VidZNow.Models;

namespace VidZNow.Pages
{
    public class LikeModel : PageModel
    {
        private readonly AppDbContext _context;

        public LikeModel(AppDbContext context)
        {
            _context = context;
        }

        public Video Video { get; set; }

        public async Task<IActionResult> OnPostAsync(int videoId)
        {
            Video = await _context.Videos.FindAsync(videoId);
            if (Video == null)
            {
                return NotFound();
            }

            var like = new Like
            {
                VideoId = videoId,
                UserId = 1 // Assuming a logged-in user with ID 1 for simplicity
            };

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
