using AspnetCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyContext _context;
        // GET: EmployeeController

        public EmployeeController(CompanyContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var employees =  _context.Employees.ToList();
            return View(employees);
           
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int? employeeid)
        {
            var employeedetails = _context.Employees.Find(employeeid);

            return View(employeedetails);
        }

        // GET: EmployeeController/Create
        public ActionResult AddorEdit(int? employeeid)
        {
            ViewBag.PageName = employeeid == null ? "Create Employee" : "Edit Employee";
            ViewBag.isedit = employeeid == null ? false : true;
            if (employeeid==null)
            {
                return View();
            }
            else
            {
                var employeeedit = _context.Employees.Find(employeeid);
                ViewBag.PageName = "Edit Employee";
                return View(employeeedit);
            }
            
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddorEdit([Bind("EmployeeId,EmployeeName,JoiningDate,Designation,CurrentAddress,Salary")] Employee employee)
        {
            
                
                if (ModelState.IsValid)
                {
                if (employee.EmployeeId == 0)
                {

                    _context.Employees.Add(employee);
                }
                else
                {
                    _context.Employees.Update(employee);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
               
            
            return View(employee);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int? employeeid)
        {
            var employeedata = _context.Employees.Find(employeeid);
            return View(employeedata);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost,ActionName("Edit")]
        
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Post(int? employeeid, [Bind("EmployeeId,EmployeeName,JoiningDate,Designation,CurrentAddress,Salary")] Employee employee)
        {
            try
            {
               if ( employeeid != employee.EmployeeId)
                {
                    return NotFound();
                    
                }
                if (ModelState.IsValid)
                {
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View(employee);
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind("EmployeeId,EmployeeName,JoiningDate,Designation,CurrentAddress,Salary")] Employee employee)
        {
            try
            {
                if (employee.EmployeeId==id)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch
            {
                return View();
            }
            return View(employee);
        }
    }
}
