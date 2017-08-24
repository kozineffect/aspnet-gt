using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gamerTag.Models;

namespace gamerTag.Controllers
{
    public class MyDbsController : Controller
    {
        private readonly MyDbContext _context;

        public MyDbsController(MyDbContext context)
        {
            _context = context;    
        }

        // GET: MyDbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyDb.ToListAsync());
        }

        // GET: MyDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myDb = await _context.MyDb
                .SingleOrDefaultAsync(m => m.ID == id);
            if (myDb == null)
            {
                return NotFound();
            }

            return View(myDb);
        }

        // GET: MyDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Username,Email,Password,LiveStream")] MyDb myDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myDb);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(myDb);
        }

        // GET: MyDbs/Edit/5
        public async Task<IActionResult> Edit()
        {
            return View(await _context.MyDb.ToListAsync());
        }

        // POST: MyDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Username,Email,Password,LiveStream")] MyDb myDb)
        {
            if (id != myDb.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyDbExists(myDb.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(myDb);
        }

        // GET: MyDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myDb = await _context.MyDb
                .SingleOrDefaultAsync(m => m.ID == id);
            if (myDb == null)
            {
                return NotFound();
            }

            return View(myDb);
        }

        // POST: MyDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myDb = await _context.MyDb.SingleOrDefaultAsync(m => m.ID == id);
            _context.MyDb.Remove(myDb);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MyDbExists(int id)
        {
            return _context.MyDb.Any(e => e.ID == id);
        }
    }
}
