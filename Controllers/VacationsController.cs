using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb1.Data;
using Labb1.Models;

namespace Labb1.Controllers
{
    public class VacationsController : Controller
    {
        private readonly Labb1DbContext _context;

        public VacationsController(Labb1DbContext context)
        {
            _context = context;
        }

        // GET: Vacations
        public async Task<IActionResult> Index(int? selectedEmployeeId)
        {
            var vacations = _context.Vacations.Include(v => v.Employee).AsQueryable();

            if (selectedEmployeeId.HasValue)
            {
                vacations = vacations.Where(v => v.FK_EmployeeId == selectedEmployeeId);
            }

            var employees = await _context.Employees.Select(e => new SelectListItem
            {
                Text = $"{e.FirstName} {e.LastName}",
                Value = e.EmployeeId.ToString()
            }).ToListAsync();

            ViewBag.EmployeeList = employees;

            return View(await vacations.ToListAsync());
        }

        // GET: Vacations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vacations == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .FirstOrDefaultAsync(m => m.VacationId == id);
            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }

        // GET: Vacations/Create
        public IActionResult Create()
        {

            var employees = _context.Employees.Select(e => new SelectListItem
            {
                Text = $"{e.FirstName} {e.LastName}",
                Value = e.EmployeeId.ToString()
            }).ToList();

            ViewData["FK_EmployeeId"] = employees;

            return View();
        }

        // POST: Vacations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacationId,VacationType,StartDate,EndDate,ApplicationDate,FK_EmployeeId")] Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacation);
        }

        // GET: Vacations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vacations == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }
            return View(vacation);
        }

        // POST: Vacations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacationId,VacationType,StartDate,EndDate,ApplicationDate,FK_EmployeeId")] Vacation vacation)
        {
            if (id != vacation.VacationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationExists(vacation.VacationId))
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
            return View(vacation);
        }

        // GET: Vacations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vacations == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .FirstOrDefaultAsync(m => m.VacationId == id);
            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }

        // POST: Vacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vacations == null)
            {
                return Problem("Entity set 'Labb1DbContext.Vacations'  is null.");
            }
            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation != null)
            {
                _context.Vacations.Remove(vacation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationExists(int id)
        {
          return _context.Vacations.Any(e => e.VacationId == id);
        }

        public async Task<IActionResult> Admin(DateTime? selectedMonth)
        {
            var vacations = _context.Vacations.Include(v => v.Employee).AsQueryable();

            if (selectedMonth.HasValue)
            {
                var startOfMonth = new DateTime(selectedMonth.Value.Year, selectedMonth.Value.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                vacations = vacations.Where(v => v.ApplicationDate >= startOfMonth && v.ApplicationDate <= endOfMonth);
            }

            var vacationsAdmin = await vacations.ToListAsync();
            return View(vacationsAdmin);
        }
    }
}
