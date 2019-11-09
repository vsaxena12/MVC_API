using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Emp_Consume_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emp_Consume_API.Controllers
{
    public class DepartmentsController : Controller
    {
        HttpClient client = new HttpClient();


        public async Task<List<Departments>> GetAllEmployee()
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Departments> empList = new List<Departments>();
            HttpResponseMessage response = await client.GetAsync("api/departments");

            if (response.IsSuccessStatusCode)

                return (await response.Content.ReadAsAsync<List<Departments>>());
            else
                return null;


        }

        public async Task<int> AddEmployee(Departments emp)
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync("api/departments", emp);

            if (response.IsSuccessStatusCode)

                return (emp.ID);
            else
                return 0;


        }

        public async Task<Departments> FetchEmployee(int id)
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Departments> empList = new List<Departments>();
            HttpResponseMessage response = await client.GetAsync($"api/departments/{id}");

            if (response.IsSuccessStatusCode)

                return (await response.Content.ReadAsAsync<Departments>());
            else
                return null;


        }

        public async Task<Departments> Update(Departments employees)
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Departments> empList = new List<Departments>();
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/departments/{employees.ID}", employees);

            if (response.IsSuccessStatusCode)

                return (await response.Content.ReadAsAsync<Departments>());
            else
                return null;


        }
        public async Task<Departments> DeleteEmp(int id)
        {
            client.BaseAddress = new Uri("http://localhost:54454/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Departments> empList = new List<Departments>();
            HttpResponseMessage response = await client.DeleteAsync($"api/departments/{id}");

            if (response.IsSuccessStatusCode)

                return (await response.Content.ReadAsAsync<Departments>());
            else
                return null;


        }
        public async Task<ActionResult> Edit(int id)
        {
            var data = await FetchEmployee(id);

            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Departments employees)
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
        public async Task<ActionResult> Delete(Departments employees)
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
        public async Task<ActionResult> Create(Departments employees)
        {
            var res = await AddEmployee(employees);
            if (res != 0)
                return RedirectToAction("Index");
            else
                return View();
        }
    }
}