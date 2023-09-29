using GogoDriver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace GogoDriver.Controllers
{
    public class ApiController : Controller
    {
        private string id;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<bool> AddclientAsync(Client clientInfo)
        {

            if (clientInfo.ProdId == "0")
            {
                string json = JsonConvert.SerializeObject(clientInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                string url = "http://192.168.1.104:7089/api/client/AddClient";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(clientInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                string url = "http://192.168.1.104:7089/api/client/UpdateClient/" + clientInfo.ProdId;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.PutAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(true);


        }


        public async Task<bool> DeleteclientAsync(Client clientInfo)
        {

            HttpClient client = new HttpClient();
            string url = "http://192.168.1.104:7089/api/client/DeleteClient/" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.DeleteAsync("");

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }

            else
            {
                return await Task.FromResult(false);
            }
        }


        public async Task<Client> GetClientAsync(int id)
        {
            var client = new Client();
            _ = new HttpClient();
            string url = "http://192.168.1.104:7089/api/client/" + id;
            client.BaseAddress =new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                client = JsonConvert.DeserializeObject<Client>(content);
            }
            return await Task.FromResult(client);
        }


        public async Task<List<Client>> GetclientAsync(int id)
        {
            var clientList = new List<Client>();
            HttpClient client = new HttpClient();
            string url = "http://192.168.1.104:7089/api/client/";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                clientList = JsonConvert.DeserializeObject<List<Client>>(content);
            }
            return await Task.FromResult(clientList);
        }

    }
}


