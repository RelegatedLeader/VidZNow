using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VidZNow.Data;
using VidZNow.Models; // Assuming Video model namespace

namespace VidZNow.Pages
{
    public class SynthesizeModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public string VideoUrl { get; set; }

        [BindProperty]
        public string Summary { get; set; }

        public SynthesizeModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Create Video object
            var newVideo = new Video
            {
                Title = "Video Title", // Set a default title or fetch it based on your logic
                Description = "Video Description", // Set a default description or fetch it based on your logic
                Url = VideoUrl // Use the submitted URL directly
            };

            // Save the video to database
            _context.Videos.Add(newVideo);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
