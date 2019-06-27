using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AgentApp.CloudModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AverageRatingController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<AverageRatingCloud> AverageRatings(long id)
        {
            string ratingString = GetAverageRatings(id).Result;
            var result = JsonConvert.DeserializeObject<AverageRatingCloud[]>(ratingString);
            return result[0];
        }

        static async Task<string> GetAverageRatings(long id)
        {
            string baseUrl = "https://xml-megatravel.appspot.com/api/reviews/average/" + id;
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