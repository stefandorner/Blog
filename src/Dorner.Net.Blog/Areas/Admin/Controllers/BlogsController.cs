using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dorner.Services.Blog.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Dorner.Services.Blog.EntityFramework.Mappers;
using Dorner.Services.Blog.Extensions.Repositories;

namespace Dorner.Net.Blog.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class BlogsController : Controller
    {

        private readonly BlogEngineStore _context;

        public BlogsController(BlogEngineStore context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.GetBlogs());
        }
        
    }
}
