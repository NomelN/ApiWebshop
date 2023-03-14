using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ApiWebshop.Controllers
{
    
    [Route("api/webshop/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        [HttpGet(Name = "GetProduits")]
        public async Task<ActionResult<Produits>> GetProducts()
        {
            var data = new List<dynamic>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync("https://615f5fb4f7254d0017068109.mockapi.io/api/v1/products");
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<dynamic[]>(jsonString);
                    

                    foreach (var product in products)
                    {
                        data.Add(new 
                        {
                            id = product.id.Value,
                            CreatedAt = product.createdAt.Value,
                            name = product.name.Value,
                            description = product.details.description.Value,
                            price = product.details.price.Value,
                            color = product.details.color.Value,
                            stock = product.stock.Value
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
       
        [HttpGet("{idProduit}", Name = "Get Produit By Id")]

        public async Task<ActionResult<Produits>> GetProduitById(int idProduit)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"https://615f5fb4f7254d0017068109.mockapi.io/api/v1/products/{idProduit}");
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<dynamic>(jsonString);

                    var result = new
                    {
                        id = product.id.Value,
                        CreatedAt = product.createdAt.Value,
                        name = product.name.Value,
                        description = product.details.description.Value,
                        price = product.details.price.Value,
                        color = product.details.color.Value,
                        stock = product.stock.Value
                    };

                    return Ok(JsonConvert.SerializeObject(result));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de récupérer le produit avec l'id " + idProduit + ": " + e.Message);
                return BadRequest();
            }
        }

    }
}
