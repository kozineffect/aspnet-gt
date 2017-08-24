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
    public class TournamentController : Controller
    {
        private readonly MyDbContext _context;

        public TournamentController(MyDbContext context)
        {
            _context = context;
        }

        // GET: MyDbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyDb.ToListAsync());
        }
    }
}