using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eShop.UI.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace eShop.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        // public IActionResult eShop()
        // {
        //     ViewData["Message"] = "Your eShop page.";
        //     List<Product> prods = null;
        //     List<Movie> movies = null;

        //     using (HttpClient client1 = new HttpClient())
        //     {

        //         // MediaTypeWithQualityHeaderValue contentType1 = 
        //         //         new MediaTypeWithQualityHeaderValue("application/json");
        //         // client1.DefaultRequestHeaders.Accept.Add(contentType1);
        //         HttpResponseMessage response1 = null;
        //         string stringData1 = null;

        //         #region "Get Products"
        //         // client1.BaseAddress = new Uri
        //         //     ("http://52.168.134.186");

        //         var reqUri1 = new Uri("http://52.168.134.186/api/products");
        //         var request1 = new HttpRequestMessage(HttpMethod.Get, reqUri1);
        //         request1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //         response1 = client1.SendAsync(request1).Result;

        //         // response1 = client1.GetAsync
        //         //     (request).Result;
        //         stringData1 = response1.Content.
        //             ReadAsStringAsync().Result;
        //         prods = JsonConvert.DeserializeObject
        //             <List<Product>>(stringData1);

        //         #endregion

        //     }

        //     using (HttpClient client2 = new HttpClient())
        //     {

        //         // MediaTypeWithQualityHeaderValue contentType2 = 
        //         //         new MediaTypeWithQualityHeaderValue("application/json");
        //         // client2.DefaultRequestHeaders.Accept.Add(contentType2);
        //         HttpResponseMessage response2 = null;
        //         string stringData2 = null;

        //         #region "Get Movies"
        //         // client2.BaseAddress = new Uri
        //         //     ("http://52.168.130.3");

        //         var reqUri2 = new Uri("http://52.168.130.3/api/movies");
        //         var request2 = new HttpRequestMessage(HttpMethod.Get, reqUri2);
        //         request2.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //         response2 = client2.SendAsync(request2).Result;

        //         // response2 = client2.GetAsync
        //         //     ("/api/movies").Result;
        //         stringData2 = response2.Content.
        //             ReadAsStringAsync().Result;
        //         movies = JsonConvert.DeserializeObject
        //             <List<Movie>>(stringData2);

        //         #endregion

        //     }

        //         var eShopData = new eShopData();
        //         eShopData.Products = prods;
        //         eShopData.Movies = movies;

        //         return View(eShopData);s
        // }
        public IActionResult Product()
        {
            ViewData["Message"] = "Your Products page.";
            List<Product> prods = null;

            using (HttpClient client1 = new HttpClient())
            {

                // MediaTypeWithQualityHeaderValue contentType1 = 
                //         new MediaTypeWithQualityHeaderValue("application/json");
                // client1.DefaultRequestHeaders.Accept.Add(contentType1);
                HttpResponseMessage response1 = null;
                string stringData1 = null;

                #region "Get Products"
                // client1.BaseAddress = new Uri
                //     ("http://52.168.134.186");

                var reqUri1 = new Uri("http://52.168.134.186/api/products");
                var request1 = new HttpRequestMessage(HttpMethod.Get, reqUri1);
                request1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response1 = client1.SendAsync(request1).Result;

                // response1 = client1.GetAsync
                //     (request).Result;
                stringData1 = response1.Content.
                    ReadAsStringAsync().Result;
                prods = JsonConvert.DeserializeObject
                    <List<Product>>(stringData1);

                #endregion

            }

            return View(prods);
        }
        public IActionResult Movie()
        {
            ViewData["Message"] = "Your Movies page.";
            List<Movie> movies = null;

            using (HttpClient client2 = new HttpClient())
            {

                // MediaTypeWithQualityHeaderValue contentType2 = 
                //         new MediaTypeWithQualityHeaderValue("application/json");
                // client2.DefaultRequestHeaders.Accept.Add(contentType2);
                HttpResponseMessage response2 = null;
                string stringData2 = null;

                #region "Get Movies"
                // client2.BaseAddress = new Uri
                //     ("http://52.168.130.3");

                var reqUri2 = new Uri("http://52.168.130.3/api/movies");
                var request2 = new HttpRequestMessage(HttpMethod.Get, reqUri2);
                request2.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response2 = client2.SendAsync(request2).Result;

                // response2 = client2.GetAsync
                //     ("/api/movies").Result;
                stringData2 = response2.Content.
                    ReadAsStringAsync().Result;
                movies = JsonConvert.DeserializeObject
                    <List<Movie>>(stringData2);

                #endregion

            }

            return View(movies);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
