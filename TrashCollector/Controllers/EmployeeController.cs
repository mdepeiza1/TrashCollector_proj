using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TrashCollector.Data;
using TrashCollector.Models;
using TrashCollector.Secret;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        bool init = true;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var e = _context.Employees.Where(e0 => e0.IdentityUserId ==
            userId).FirstOrDefault();
            ////var applicationDbContext = _context.Employees.Include(e => e.IdentityUser);
            //var applicationDbContext = _context.Customers.Where(c => c.ZipCode == e.ZipCode);
            //    //.Where(a => a.DayOfWeekChosenByCustomer == DateTime.Today.DayOfWeek);//.Include(c => c.IdentityUser).Where(c=>c.ZipCode == e.ZipCode); //test this line
            //applicationDbContext.Where(a => a.DayOfWeekChosenByCustomer == DateTime.Today.DayOfWeek);
        
            
            if (e == null)
            {
                    // Redirect to create action
                    return RedirectToAction("Create");
                //var applicationDbContext = _context.Customers.Where(c => c.ZipCode == 0);
                //return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                //var applicationDbContext = _context.Customers.Where(c => c.ZipCode == e.ZipCode);
                //if (init)
                //{
                //    //var applicationDbContext = _context.Customers.Where(c => c.ZipCode == e.ZipCode);
                //    int dayOfWeek = (int)DateTime.Today.DayOfWeek;
                //    var applicationDbContext = _context.Customers.Where(c => (int)c.DayOfWeekChosenByCustomer == dayOfWeek
                //    && c.ZipCode == e.ZipCode);
                //    //&& c.DayOfWeekChosenByCustomer.Equals(DateTime.Today.DayOfWeek));
                //    //applicationDbContext = applicationDbContext.Where(a => a.DayOfWeekChosenByCustomer == DateTime.Today.DayOfWeek);
                //    init = false;
                //    return View(await applicationDbContext.ToListAsync());
                //}
                //else
                //{
                int dayOfWeek = (int)e.DayOfWeekSelectedByEmployee;

                //Enumerable.Cast<int>(_context.Customers.Select(c=> c.ExtraDay.DayOfWeek));
                //Enumerable.Cast<int>(_context.Customers.Select(c => c.DayOfWeekChosenByCustomer));
                var applicationDbContext = _context.Customers.ToList().Where(c => ((int)c.DayOfWeekChosenByCustomer == dayOfWeek ||
                    (int)c.ExtraDay.DayOfWeek == dayOfWeek) && c.ZipCode == e.ZipCode && (!(c.StartDateOfSuspension < DateTime.Today && DateTime.Today < c.EndDateOfSuspension)));
                
                //applicationDbContext.Where(c => c.ZipCode == e.ZipCode);

                //var applicationDbContext = _context.Customers.Where(c => (int)c.DayOfWeekChosenByCustomer == dayOfWeek ||
                //     (int)c.ExtraDay.DayOfWeek == dayOfWeek
                //    && c.ZipCode == e.ZipCode);

                //&& c.DayOfWeekChosenByCustomer.Equals(e.DayOfWeekSelectedByEmployee));
                //applicationDbContext = applicationDbContext.Where(a => a.DayOfWeekChosenByCustomer == e.DayOfWeekSelectedByEmployee);
                return View(applicationDbContext);
                //}
            }
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null)
            {
                return NotFound();
            }


            return View(customer);
        }

        //// GET: Employee/Details/5
        //public async Task<IActionResult> MapDetails(int? id) // update this
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customers
        //        .Include(e => e.IdentityUser)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    if (customer.NormalPickedUp && customer.ExtraPickedUp)
        //    {
        //        customer.AmountToPay = 50;
        //    }
        //    else if (customer.NormalPickedUp)
        //    {
        //        customer.AmountToPay = 30;
        //    }
        //    else if (customer.ExtraPickedUp)
        //    {
        //        customer.AmountToPay = 20;
        //    }
        //    else
        //    {
        //        customer.AmountToPay = 0;
        //    }

        //    return View(customer);
        //}

        // GET: Employee/Create
        public IActionResult Create()
        {
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                employee.DayOfWeekSelectedByEmployee = DateTime.Today.DayOfWeek;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", employee.CustomerId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", employee.CustomerId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var c = _context.Customers.Where(c0 => c0.Id == customer.Id).FirstOrDefault();
                    customer.IdentityUserId = c.IdentityUserId;
                    //_context.Customers.Remove(c);
                    //_context.Customers.Add(customer);
                    //_context.Customers.Update(customer);
                    c.NormalPickedUp = customer.NormalPickedUp;
                    c.ExtraPickedUp = customer.ExtraPickedUp;
                    //_context.Update(customer.NormalPickedUp);
                    //_context.Update(customer.ExtraPickedUp);

                    if (customer.NormalPickedUp && customer.ExtraPickedUp)
                    {
                        c.AmountToPay = 50;
                    }
                    else if (customer.NormalPickedUp)
                    {
                        c.AmountToPay = 30;
                    }
                    else if (customer.ExtraPickedUp)
                    {
                        c.AmountToPay = 20;
                    }
                    else
                    {
                        c.AmountToPay = 0;
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", employee.CustomerId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }





        // GET: Employee/Edit/5
        public async Task<IActionResult> EditIndex()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var e = _context.Employees.Where(e0 => e0.IdentityUserId ==
            userId).FirstOrDefault();

            //var employee = await _context.Employees.FindAsync(id);
            if (e == null)
            {
                return NotFound();
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", employee.CustomerId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", e.IdentityUserId);
            return View(e);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIndex(Employee e)
        {
            //if (id != e.Id)
            //{
            //    return NotFound();
            //}

            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var e2 = _context.Employees.Where(e1 => e1.IdentityUserId ==
            //userId).FirstOrDefault();
            init = false;
            if (ModelState.IsValid)
            {
                try
                {
                    var e1 = _context.Employees.Where(e0 => e0.Id == e.Id).FirstOrDefault();
                    _context.Employees.Remove(e1);
                    e.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _context.Employees.Add(e);
                    //_context.Employees.Update(e);
                    //_context.Update(e);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(e.Id))
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
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", employee.CustomerId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", e.IdentityUserId);
            return View(e);
        }



        // GET: Employee/Details/5
        public async Task<IActionResult> SingleMapDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //HttpClient httpClient = new HttpClient();
            //HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var customer = await _context.Customers
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            //JsonConvert.DeserializeObject(await httpClient.GetAsync(String.Format("https://maps.googleapis.com/maps/api/geocode/json?address=Winnetka&bounds=34.172684,-118.604794|34.236144,-118.500938&key=AIzaSyDmxMLmkJyc8XIRXchW7ISQ332UEPz6ME8", API_Key.Key)));


            if (customer == null)
            {
                return NotFound();
            }


            return View(customer);
        }












        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.Id == id);
        }

        // GET: Employee/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        public async Task<IActionResult> Delete()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var e = _context.Employees.Where(e0 => e0.IdentityUserId ==
            userId).FirstOrDefault();

            //var employee = await _context.Employees.FindAsync(id);
            if (e == null)
            {
                return NotFound();
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", employee.CustomerId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", e.IdentityUserId);
            return View(e);



            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employee = await _context.Employees
            //    .Include(e => e.IdentityUser)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
