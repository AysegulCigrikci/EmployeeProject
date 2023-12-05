using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EmployeeProject.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Controllers
{
    public class HomeController : Controller
    {
        EmployeeManager cm = new EmployeeManager(new EfEmployeeRepository());

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //Index Sayfasınada personeller listeleniyor
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }

        //Personel Detay
        public IActionResult Detail(int id)
        {
            var values = cm.GetEmployeeByID(id);
            return View(values);
        }

        //id ye göre güncellenecek data getiriliyor
        [HttpGet]
        public IActionResult Update(int id)
        {
            var employeeValue = cm.GetById(id);//id
            return View(employeeValue);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            cm.EmployeeUpdate(employee);
            return RedirectToAction("Index", "Home");
        }


        //id ye göre silme işlemi
        public IActionResult Delete(int id)
        {
            var employeValue = cm.GetById(id); //id 
            cm.EmployeeDelete(employeValue);
            return RedirectToAction("Index", "Home");
        }

        //Yeni Personel Ekle
        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            //Validasyon kuralları kaydetme işleminde
            EmployeeValidator ev = new EmployeeValidator();
            ValidationResult results = ev.Validate(employee);

            if(results.IsValid)
            { 
            cm.EmployeeAdd(employee);
            return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
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

        public IActionResult Test()
        {
            return View() ;
        }
    }
}
