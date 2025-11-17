using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext dbContext;
        public EmployeeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            // Shows the Add Employee page
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Idcard = viewModel.Idcard
                };


                await dbContext.Employees.AddAsync(employee);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var employees = await dbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var emp = await dbContext.Employees.FindAsync(id);
            return View(emp);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(Employee viewModel)
        {
            var emp = await dbContext.Employees.FindAsync(viewModel.Id);

            if (emp is not null)
            {
                emp.Name = viewModel.Name;
                emp.Email = viewModel.Email;
                emp.Phone = viewModel.Phone;
                emp.Idcard = viewModel.Idcard;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employee");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Employee viewModel)
        {
            var emp = await dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (emp is not null)
            {
                dbContext.Employees.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employee");
        }
    }
}
