using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCORE_MVC.Models;

namespace EFCORE_MVC.Controllers
{
    public class EfcoreEmployeesController : Controller
    {
        private readonly EfcoreContext _context;

        public EfcoreEmployeesController(EfcoreContext context)
        {
            _context = context;
        }

        // GET: EfcoreEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.EfcoreEmployees.ToListAsync());
        }

        // GET: EfcoreEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efcoreEmployee = await _context.EfcoreEmployees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (efcoreEmployee == null)
            {
                return NotFound();
            }

            return View(efcoreEmployee);
        }

        // GET: EfcoreEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EfcoreEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Department")] EfcoreEmployee efcoreEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(efcoreEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(efcoreEmployee);
        }

        // GET: EfcoreEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efcoreEmployee = await _context.EfcoreEmployees.FindAsync(id);
            if (efcoreEmployee == null)
            {
                return NotFound();
            }
            return View(efcoreEmployee);
        }

        // POST: EfcoreEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Department")] EfcoreEmployee efcoreEmployee)
        {
            if (id != efcoreEmployee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(efcoreEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EfcoreEmployeeExists(efcoreEmployee.EmployeeId))
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
            return View(efcoreEmployee);
        }

        // GET: EfcoreEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efcoreEmployee = await _context.EfcoreEmployees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (efcoreEmployee == null)
            {
                return NotFound();
            }

            return View(efcoreEmployee);
        }

        // POST: EfcoreEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var efcoreEmployee = await _context.EfcoreEmployees.FindAsync(id);
            if (efcoreEmployee != null)
            {
                _context.EfcoreEmployees.Remove(efcoreEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EfcoreEmployeeExists(int id)
        {
            return _context.EfcoreEmployees.Any(e => e.EmployeeId == id);
        }
    }
}
