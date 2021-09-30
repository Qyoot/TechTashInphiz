using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTech.DbContextFolder;
using TaskTech.DbModel;

namespace TaskTech.Controllers
{
    public class UserLoginAtemptsController : Controller
    {
        private readonly DataContext _context;

        public UserLoginAtemptsController(DataContext context)
        {
            _context = context;
        }

        // GET: UserLoginAtempts
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserLoginAtempts.ToListAsync());
        }

        // GET: UserLoginAtempts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLoginAtempt = await _context.UserLoginAtempts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLoginAtempt == null)
            {
                return NotFound();
            }

            return View(userLoginAtempt);
        }

        // GET: UserLoginAtempts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserLoginAtempts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AttemptTime,IsSuccess")] UserLoginAtempt userLoginAtempt)
        {
            if (ModelState.IsValid)
            {
                userLoginAtempt.Id = Guid.NewGuid();
                _context.Add(userLoginAtempt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLoginAtempt);
        }

        // GET: UserLoginAtempts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLoginAtempt = await _context.UserLoginAtempts.FindAsync(id);
            if (userLoginAtempt == null)
            {
                return NotFound();
            }
            return View(userLoginAtempt);
        }

        // POST: UserLoginAtempts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AttemptTime,IsSuccess")] UserLoginAtempt userLoginAtempt)
        {
            if (id != userLoginAtempt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLoginAtempt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLoginAtemptExists(userLoginAtempt.Id))
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
            return View(userLoginAtempt);
        }

        // GET: UserLoginAtempts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLoginAtempt = await _context.UserLoginAtempts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLoginAtempt == null)
            {
                return NotFound();
            }

            return View(userLoginAtempt);
        }

        // POST: UserLoginAtempts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userLoginAtempt = await _context.UserLoginAtempts.FindAsync(id);
            _context.UserLoginAtempts.Remove(userLoginAtempt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLoginAtemptExists(Guid id)
        {
            return _context.UserLoginAtempts.Any(e => e.Id == id);
        }
    }
}
