using HUB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HUB.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7223/api/customer";

            List<Customer> customers = new List<Customer>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                customers = JsonConvert.DeserializeObject<List<Customer>>(result);
            }
            return View(customers);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            string apiUrl = "https://localhost:7223/api/customer";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }


        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Customer customer)
        {
            string apiUrl = "https://localhost:7223/api/customer";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Delete));
                }
            }
            return View(customer);
        }
    }
}
