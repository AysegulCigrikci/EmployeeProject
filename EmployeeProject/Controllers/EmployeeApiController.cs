using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.Controllers
{
    public class EmployeeApiController : Controller
    {
        //personel listeleme
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44323/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync(); //Json Dönüyor
            var values = JsonConvert.DeserializeObject<List<ClassEmp1>>(jsonString);
            return View(values);//Deserialize:Json verilerini .net nesnesine dönüştürüyor
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        //api personel ekleme
        [HttpPost]
        public async Task<IActionResult> AddEmployee(ClassEmp1 emp)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(emp);//Serialize:jsona çeviriyoruz
            StringContent content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44323/api/Default",content);//ekleme oldugu için PostAsync
            if (responseMessage.IsSuccessStatusCode)//başarılı 200
            {
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        //güncelleme için id ye göre veriyi getirme
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44323/api/Default/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ClassEmp1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        //personel güncelleme
        [HttpPost]
        public async Task<IActionResult> EditEmployee(ClassEmp1 emp)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(emp);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44323/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        //Personel silme işlemi
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44323/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        public class ClassEmp1
        {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeGender { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhoneNumber { get; set; }
        }
    }
    
}
