using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaOrderingSystemAPI.Models;
using PizzaOrderingSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingSystemProject.Controllers
{
    public class PizzaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string Baseurl = "http://localhost:1229/";
            var PizzaInfo = new List<Pizza>();
            //HttpClient cl = new HttpClient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Pizzas");

                if (Res.IsSuccessStatusCode)
                {
                    var PizzaResponse = Res.Content.ReadAsStringAsync().Result;
                    PizzaInfo = JsonConvert.DeserializeObject<List<Pizza>>(PizzaResponse);
                }
                return View(PizzaInfo);
            }
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            TempData["CurrentPizzaId"] = id;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CustomerDetails p)
        {
            CustomerDetails customer = new CustomerDetails();
            Order orderInfo = new Order();
            int pizzaId = Convert.ToInt32(TempData["CurrentPizzaId"]);
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:1229/api/CustomerDetails", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<CustomerDetails>(apiResponse);
                }

                if (customer != null && customer.DetailsId > 0)
                {
                    orderInfo = new Order() { PizzaId = pizzaId, DetailsId= customer.DetailsId };
                    content = new StringContent(JsonConvert.SerializeObject(orderInfo), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("http://localhost:1229/api/Orders", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        orderInfo = JsonConvert.DeserializeObject<Order>(apiResponse);
                    }
                }
            }
            return RedirectToAction("OrderSummary", orderInfo);
        }
        [HttpGet]
        public async Task<ActionResult> OrderSummary(Order input)
        {
            Pizza pizza = new Pizza();
            CustomerDetails customer = new CustomerDetails();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("http://localhost:1229/api/Pizzas/" + input.PizzaId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pizza = JsonConvert.DeserializeObject<Pizza>(apiResponse);
                }
                using (var response = await httpClient.GetAsync("http://localhost:1229/api/CustomerDetails/" + input.DetailsId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<CustomerDetails>(apiResponse);
                }
            }

            OrderInfo b = new OrderInfo() { OrderId = input.OrderId, Pizzas = pizza, CustomerDetails = customer };

            return View("Order",b);
        }

        public ActionResult ConfirmOrder()
        {
           
            return View();
        }

    }
    }
      