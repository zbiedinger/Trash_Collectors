using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trash_Collector.ActionFilters;
using Trash_Collector.Data;
using Trash_Collector.Models;

namespace Trash_Collector.Controllers
{
    //[ServiceFilter(typeof(GlobalRouting))]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers to view
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }

            var customers = GetPickupsByZip(employee.ZipCode);
            customers = GetTodaysPickups(customers, DateTime.Today);

            return View(customers);
        }

        [HttpPost, ActionName("PickupComplete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PickupComplete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Customer.Where(c => c.Id == id).SingleOrDefault();

            if (ModelState.IsValid)
            {
                customer.LastPickup = DateTime.Now;
                ChargeCustomer(customer);
                _context.Update(customer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        //// POST: Employees
        //[HttpPost, ActionName("PickupComplet")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var employee = await _context.Employee.FindAsync(id);
        //    _context.Employee.Remove(employee);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        // GET: Employees/pickups
        public IActionResult Pickups()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            var customers = GetPickupsByZip(employee.ZipCode);
            customers = GetTodaysPickups(customers, DateTime.Today);
            return View(customers);
        }

        // POST: Customers to view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pickups(DateTime pickupdate)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }

            var customers = GetPickupsByZip(employee.ZipCode);
            customers = GetTodaysPickups(customers, pickupdate);

            return View(customers);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ZipCode,Address,Pay")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Employee employeeCreate = new Employee();
                employeeCreate.IdentityUserId = userId;
                employeeCreate.FirstName = employee.FirstName;
                employeeCreate.LastName = employee.LastName;
                employeeCreate.ZipCode = employee.ZipCode;
                employeeCreate.Address = employee.Address;
                employeeCreate.Pay = employee.Pay;

                _context.Add(employeeCreate);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ZipCode,Address,Pay,IdentityUserId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }



        public IEnumerable<Customer> GetPickupsByZip(int zip)
        {
            var customersByZip = _context.Customer.Where(c => c.ZipCode == zip);
            return customersByZip;
        }

        //Returns the Customers that need pickup on a passed in date
        public IEnumerable<Customer> GetTodaysPickups(IEnumerable<Customer> customersForpickup, DateTime dateOfPickup)
        {
            string dayOfWeek = dateOfPickup.DayOfWeek.ToString();

            customersForpickup = customersForpickup.Where(c => c.PickupDay == dayOfWeek || c.ExtraPickupDay == dateOfPickup).AsEnumerable();
            customersForpickup = CheckifSuspended(customersForpickup, dateOfPickup);

            return customersForpickup;
        }

        //checks if a customer's service is suspended
        public IEnumerable<Customer> CheckifSuspended(IEnumerable<Customer> customersNotSuspended, DateTime dateOfPickup)
        {
            foreach (var Item in customersNotSuspended)
            {
                if (dateOfPickup.Ticks > Item.SuspendedStart.Ticks && dateOfPickup.Ticks < Item.SuspendedEnd.Ticks)
                {
                    Item.IsSuspended = true;
                }
                else
                {
                    Item.IsSuspended = false;
                }
            }
            customersNotSuspended = customersNotSuspended.Where(c => c.IsSuspended == false);

            return customersNotSuspended;
        }

        //Charge customer base on servise
        public void ChargeCustomer(Customer customer)
        {
            if (customer.ExtraPickupDay.Date == DateTime.Today.Date)
            {
                customer.ChargesDue += 35;
            }
            else
            {
                customer.ChargesDue += 15;
            }
            _context.Update(customer);
        }
    }
}
