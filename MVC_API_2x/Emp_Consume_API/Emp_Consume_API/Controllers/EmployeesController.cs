using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emp_Consume_API.Data;
using Emp_Consume_API.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Emp_Consume_API.Controllers
{
    public class EmployeesController : Controller
    {
        HttpClient client = new HttpClient();


        public async Task<List<Employees>> GetAllEmployee()
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Employees> empList = new List<Employees>();
            HttpResponseMessage response = await client.GetAsync("api/employees");

            if (response.IsSuccessStatusCode)

                return (await response.Content.ReadAsAsync<List<Employees>>());
            else
                return null;


        }

        public async Task<int> AddEmployee(Employees emp)
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Employees", emp);

            if (response.IsSuccessStatusCode)

                return (emp.ID);
            else
                return 0;


        }

        public async Task<Employees> FetchEmployee(int id)
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Employees> empList = new List<Employees>();
            HttpResponseMessage response = await client.GetAsync($"api/Employees/{id}");

            if (response.IsSuccessStatusCode)

                return (await response.Content.ReadAsAsync<Employees>());
            else
                return null;


        }

        public async Task<Employees> Update(Employees employees)
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Employees> empList = new List<Employees>();
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Employees/{employees.ID}", employees);

            if (response.IsSuccessStatusCode)

                return (await response.Content.ReadAsAsync<Employees>());
            else
                return null;


        }
        public async Task<Employees> DeleteEmp(int id)
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Employees> empList = new List<Employees>();
            HttpResponseMessage response = await client.DeleteAsync($"api/Employees/{id}");

            if (response.IsSuccessStatusCode)

                return (await response.Content.ReadAsAsync<Employees>());
            else
                return null;


        }
        public async Task<ActionResult> Edit(int id)
        {
            var data = await FetchEmployee(id);

            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Employees employees)
        {
            var res = await Update(employees);
            if (res == null)
                return RedirectToAction("Index");
            else
                return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            var data = await FetchEmployee(id);

            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Employees employees)
        {
            var data = await DeleteEmp(employees.ID);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Index()
        {
            var data = await GetAllEmployee();

            return View(data);
        }

        public async Task<ActionResult> Details(int id)
        {
            var data = await FetchEmployee(id);

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employees employees)
        {
            var res = await AddEmployee(employees);
            if (res != 0)
                return RedirectToAction("Index");
            else
                return View();
        }
    }
}
