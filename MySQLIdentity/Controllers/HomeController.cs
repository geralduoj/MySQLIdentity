using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySQLIdentity.Models;

namespace MySQLIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployeeRepository _employeeRepository;
        private readonly workforceContext _workforceContext;

        public HomeController(ILogger<HomeController> logger, workforceContext workforceContext)
        {
            _logger = logger;
            _workforceContext = workforceContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Emps = _workforceContext.Employee.ToList();
            return View(await _workforceContext.Employee.ToListAsync()); //_workforceContext.Employee.ToListAsync()); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
