using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidZNow.Data;
using VidZNow.Models;

namespace VidZNow.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Video> RecentVideos { get; set; }

        public async Task OnGetAsync()
        {
            RecentVideos = await _context.Videos
                .Include(v => v.Comments)
                    .ThenInclude(c => c.Likes)
                .ToListAsync();

            foreach (var video in RecentVideos)
            {
                video.TopComments = video.Comments.OrderByDescending(c => c.Likes.Count).Take(5).ToList();
            }
        }


        public async Task<IActionResult> OnPostLikeAsync(int videoId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            if (video == null)
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

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCommentAsync(int videoId, string content)
        {
            var video = await _context.Videos.FindAsync(videoId);
            if (video == null)
            {
                return NotFound();
            }

            var comment = new Comment
            {
                VideoId = videoId,
                UserId = 1, // Assuming a logged-in user with ID 1 for simplicity
                Content = content,
                CreatedAt = DateTime.Now
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}



/*using Microsoft.AspNetCore.Mvc.RazorPages;
using VidZNow.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace VidZNow.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Video> Videos { get; set; }

        public void OnGet()
        {
            Videos = _context.Videos.ToList();
        }
    }
}*/