using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFCoreRepositoryPatternDemo.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreRepositoryPatternDemo.Controllers
{
    public class ExperiencePortalController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ExperiencePortalController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: ExperiencePortalController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ClsEmployee employee)
        {
            ClsEmployee emp = _employeeRepository.GetEmployee(employee);
            if (emp != null)
            {
                HttpContext.Session.SetInt32("EmployeeID", emp.EmpID); // In this way only we declare session variable
                return RedirectToAction("Details");
            }
            else
            {
                ViewData["Status"] = "Invalid user id or password";
                return View();
            }


        }

        // GET: ExperiencePortalController/Details/5
        public ActionResult Details()
        {
            if (HttpContext.Session.GetInt32("EmployeeID") != null)
            {
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("EmployeeID"));
                ClsEmployee employee = _employeeRepository.GetEmployeeByID(id); // as id==empid as we set session variable as empid
                ViewBag.EmpID = employee.EmpID;

                ViewBag.FirstName = employee.FirstName;
                ViewBag.LastName = employee.LastName;
                ViewBag.CellNumber = employee.CellNumber;
                ViewBag.Email = employee.Email;


                IEnumerable<ClsSkill> skills = _employeeRepository.GetAllSkill(employee.EmpID);
                ViewBag.TotalYearsOfExp = skills.Sum(s => s.ExperienceInYears);
                return View(skills);
            }
            else
            {
                return RedirectToAction(nameof(Index));

            }
        }

        // GET: ExperiencePortalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExperiencePortalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("EmpID,FirstName,LastName,Password,CellNumber,Email")] ClsEmployee clsEmployee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(clsEmployee);

                return RedirectToAction(nameof(Index));
            }
            return View(clsEmployee);


        }
        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(ClsSkill skill)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("EmployeeID"));
                skill.EmpID = id;
                _employeeRepository.AddSkill(skill);

                return RedirectToAction(nameof(Details));
            }
            return View(skill);
        }

        // GET: ExperiencePortalController/Edit/5
        public ActionResult Edit(int id)
        {
            ClsEmployee employee = _employeeRepository.GetEmployeeByID(id);

            return View(employee);
        }

        // POST: ExperiencePortalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClsEmployee employee)
        {
            try
            {
                _employeeRepository.Update(employee);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: ExperiencePortalController/Delete/5
        public ActionResult Delete(int id)
        {
            ClsSkill skill = _employeeRepository.GetSkill(id);
            return View(skill);
        }

        // POST: ExperiencePortalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClsSkill skill)
        {
            try
            {
                _employeeRepository.DeleteSkill(skill.SkillId);
                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Index));

        }
    }
}
