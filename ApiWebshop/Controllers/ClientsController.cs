using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiWebshop.Controllers
{
    [Route("api/webshop/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpGet(Name ="GetClients") ]
        public async Task<ActionResult<Clients>> GetClients()
        {
            var data = new List<dynamic>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync("https://615f5fb4f7254d0017068109.mockapi.io/api/v1/customers/");
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var customers = JsonConvert.DeserializeObject<dynamic[]>(jsonString);
                    

                    foreach (var customer in customers)
                    {
                        data.Add(new 
                        {
                            id = customer.id.Value,
                            createdAt = customer.createdAt,
                            name = customer.name,
                            username = customer.username,
                            firstName = customer.firstName,
                            lastName = customer.lastName,
                            address = customer.address.postalCode + " " + customer.address.city,
                            profil = customer.profile.firstName + " " + customer.profile.lastName,
                            company = customer.company.companyName,
                            orders = customer.orders
                        }) ;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de récupérer la liste des produits " + e.Message);
                return BadRequest();
            }

            return Ok(JsonConvert.SerializeObject(data));
        }

        [HttpGet("{idClient}", Name = "GetClientById")]

        public async Task<ActionResult<Clients>> GetClientById(int idClient)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"https://615f5fb4f7254d0017068109.mockapi.io/api/v1/customers/{idClient}");
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var customer = JsonConvert.DeserializeObject<dynamic>(jsonString);

                    var result = new
                    {
                        Id = customer.id,
                        CreatedAt = customer.createdAt,
                        Name = customer.name,
                        Username = customer.username,
                        FirstName = customer.firstName,
                        LastName = customer.lastName,
                        Address = customer.address.postalCode + " " + customer.address.city,
                        Profil = customer.profile.firstName + " " + customer.profile.lastName,
                        Company = customer.company.companyName,
                        Orders = customer.orders
                    };

                    return Ok(JsonConvert.SerializeObject(result));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de récupérer le produit avec l'id " + idClient + ": " + e.Message);
                return BadRequest();
            }
            
        }

        [HttpGet("{idClient}/commandes", Name = "GetOrdersById")]

        public async Task<ActionResult<Commandes>> GetOrdersById(int idClient)
        {
            var data = new List<dynamic>();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"https://615f5fb4f7254d0017068109.mockapi.io/api/v1/customers/{idClient}/orders");
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var orders = JsonConvert.DeserializeObject<dynamic>(jsonString);

                    foreach (var order in orders)
                    {
                        data.Add(new
                        {
                            idClient = order.customerId.Value,
                            idCommande = order.id.Value,
                            date = order.createdAt.Value,
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de récupérer le produit avec l'id " + idClient + ": " + e.Message);
                return BadRequest();
            }

            return Ok(JsonConvert.SerializeObject(data));
        }
        [HttpGet("{idClient}/commandes/{idCommande}/produits", Name = "Récupérer les produits d'une commande")]
        public async Task<ActionResult<string>> GetOrderProducts(string idClient, string idCommande)
        {
            var data = new List<dynamic>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"https://615f5fb4f7254d0017068109.mockapi.io/api/v1/customers/{idClient}/orders/{idCommande}/products");
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var order = JsonConvert.DeserializeObject<dynamic[]>(jsonString);

                    foreach (var product in order)
                    {
                        data.Add(new
                        {
                            idCommande = product.orderId,
                            idClient = product.id,
                            name = product.name.Value,
                            description = product.details.description.Value,
                            price = product.details.price.Value,
                            color = product.details.color.Value,
                            stock = product.stock.Value,
                            createdAt = product.createdAt.Value
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de récupérer la liste des produits " + e.Message);
                return BadRequest();
            }

            return Ok(JsonConvert.SerializeObject(data));
        }
    }
}

