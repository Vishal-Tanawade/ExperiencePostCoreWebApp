using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExperiencePostCoreWebApp.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ExperiencePostCoreWebApp.Controllers
{
    public class ExperiencePortalController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ExperiencePortalController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostEnvironment = hostEnvironment;

        }

        // GET: ExperiencePortalController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee employee)
        {
            Employee emp = _employeeRepository.GetEmployee(employee);
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
                Employee employee = _employeeRepository.GetEmployeeByID(id); // as id==empid as we set session variable as empid
                ViewBag.EmpID = employee.EmpID;

                ViewBag.FirstName = employee.FirstName;
                ViewBag.LastName = employee.LastName;
                ViewBag.CellNumber = employee.CellNumber;
                ViewBag.Email = employee.Email;
                ViewBag.ProfilePicture = employee.ProfilePicture;

                IEnumerable<Skill> skills = _employeeRepository.GetAllSkill(employee.EmpID);
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
        public ActionResult Create([Bind("EmpID,FirstName,LastName,Password,CellNumber,Email")] Employee Employeee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(Employeee);

                return RedirectToAction(nameof(Index));
            }
            return View(Employeee);


        }
        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
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
      
        // GET: EmployeesPortalController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeByID(id);

            return View(employee);
        }

        // POST: EmployeesPortalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            try
            {
                //Edit profile
                // Delete Existing Image from Upload folder
                //delete images from wwwroot/Upload folder
                string imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Upload", employee.ProfilePicture);
                if (System.IO.File.Exists(imagePath) && employee.ProfilePicture != "noImage.png")
                {
                    System.IO.File.Delete(imagePath);
                }
                // Assign updated image in database
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(employee.ImageFile.FileName);
                string extension = Path.GetExtension(employee.ImageFile.FileName);
                employee.ProfilePicture = fileName = fileName + DateTime.Now.ToString("yyyymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Upload/", fileName);

                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    await employee.ImageFile.CopyToAsync(fileStream);
                }


                // Update record



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
            Skill skill = _employeeRepository.GetSkill(id);
            return View(skill);
        }

        // POST: ExperiencePortalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Skill skill)
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
