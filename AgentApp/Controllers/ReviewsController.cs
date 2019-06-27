using AgentApp.CloudModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AgentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult<ReviewCloud[]> Reviews(long id)
        {
            string reviewString = GetReviews(id).Result;
            var result = JsonConvert.DeserializeObject<ReviewCloud[]>(reviewString);
            return result;
        }


        static async Task<string> GetReviews(long id)
        {
            string baseUrl = "https://xml-megatravel.appspot.com/api/reviews/all/" + id;
            using (HttpClient client = new HttpClient())

            using (HttpResponseMessage res = await client.GetAsync(baseUrl))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    return data;
                }
            }

            return "";
        }
    }
}
