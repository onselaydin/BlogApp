using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data;
using BlogApp.Models;

namespace BlogApp.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly BlogApp.Data.BlogAppContext _context;

        public IndexModel(BlogApp.Data.BlogAppContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Post = await _context.Posts.ToListAsync();
        }
    }
}