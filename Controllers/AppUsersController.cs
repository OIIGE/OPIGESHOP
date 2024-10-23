using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OPIGESHOP.Data;
using OPIGESHOP.Models;


namespace OPIGESHOP.Controllers
{
    public class AppUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppUsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()  //Controller
        {
          var appUsers = _context.AppUsers.ToList();      //Model
            return View(appUsers);      //View
        }


        // GET: AppUsers/Create
        public IActionResult Create()
        {
            return View();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.

        // POST: AppUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Password,Address.AddressId,Address.Street,Address.City,Address.State,Country,PostalCode")] AppUsers AppUser
            )
        {
            if (ModelState.IsValid)
            {
                _context.Add(AppUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(AppUser);
        }
        // GET: AppUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AppUser = await _context.AppUsers.FindAsync(id);
            if (AppUser == null)
            {
                return NotFound();
            }
            return View(AppUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Password,Address.AddressId,Address.Street,Address.City,Address.State,Country,PostalCode")] AppUsers AppUser)
        {
            if (id != AppUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(AppUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(AppUser.Id))
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
            return View(AppUser);
        }

        // GET: AppUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AppUser = await _context.AppUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (AppUser == null)
            {
                return NotFound();
            }

            return View(AppUser);
        }

        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var AppUser = await _context.AppUsers.FindAsync(id);
            if (AppUser != null)
            {
                _context.AppUsers.Remove(AppUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}
