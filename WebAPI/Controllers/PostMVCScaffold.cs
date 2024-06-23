using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;

namespace ESOF.WebApp.WebAPI.Controllers
{
    public class PostMVCScaffold : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostMVCScaffold(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostMVCScaffold
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Posts.Include(p => p.Creator);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PostMVCScaffold/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Creator)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: PostMVCScaffold/Create
        public IActionResult Create()
        {
            ViewData["CreatorId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: PostMVCScaffold/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,CreatorId,DateTimePost,Text,VisibilityType")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.PostId = Guid.NewGuid();
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorId"] = new SelectList(_context.Users, "UserId", "Email", post.CreatorId);
            return View(post);
        }

        // GET: PostMVCScaffold/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["CreatorId"] = new SelectList(_context.Users, "UserId", "Email", post.CreatorId);
            return View(post);
        }

        // POST: PostMVCScaffold/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PostId,CreatorId,DateTimePost,Text,VisibilityType")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorId"] = new SelectList(_context.Users, "UserId", "Email", post.CreatorId);
            return View(post);
        }

        // GET: PostMVCScaffold/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Creator)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: PostMVCScaffold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(Guid id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
