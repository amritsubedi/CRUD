using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // Index
        public IActionResult Index(int id)
        {
            var user = _context.Users;
            return View(user);
        }

        // Get: Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
            return View(user);
        }

        // Get: Users/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Post: Users/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // Get: Users/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.UserId == id);
            return View(user);
        }

        // Post: Users/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Name, PhoneNumber")]int id, User user)
        {
            if (id == user.UserId)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        // Get: Users/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.UserId == id);
            return View(user);
        }

        // Post: Users/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id, User user)
        {
            if (id == user.UserId)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}