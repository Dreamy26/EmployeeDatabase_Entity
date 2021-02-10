using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MockAssessment6.DALModels;
using MockAssessment6.Services;

namespace MockAssessment6.Controllers
{
    public class EmployeeSController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeSController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeS
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: EmployeeS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDAL = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDAL == null)
            {
                return NotFound();
            }

            return View(employeeDAL);
        }

        // GET: EmployeeS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,Age,Salary")] EmployeeDAL employeeDAL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDAL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDAL);
        }

        // GET: EmployeeS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDAL = await _context.Employees.FindAsync(id);
            if (employeeDAL == null)
            {
                return NotFound();
            }
            return View(employeeDAL);
        }

        // POST: EmployeeS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,Age,Salary")] EmployeeDAL employeeDAL)
        {
            if (id != employeeDAL.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDAL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDALExists(employeeDAL.Id))
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
            return View(employeeDAL);
        }

        // GET: EmployeeS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDAL = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDAL == null)
            {
                return NotFound();
            }

            return View(employeeDAL);
        }

        // POST: EmployeeS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDAL = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employeeDAL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDALExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
