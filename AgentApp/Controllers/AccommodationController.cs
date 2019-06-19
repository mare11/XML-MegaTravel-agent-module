using AccommodationService;
using AgentApp.Models;
using AgentDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {

        private readonly AgentContext _context;

        public AccommodationController(AgentContext context) => _context = context;

        [HttpPost]
        public ActionResult<AccommodationDTO> AddAccommodation(AccommodationDTO body)
        {
            AccommodationPortClient accPortClient = new AccommodationPortClient();
            addAccommodationRequest accRequest = new addAccommodationRequest
            {
                AccommodationDTO = body
            };

            var acc = accPortClient.addAccommodationAsync(accRequest);
            acc.Wait();

            AccommodationDTO accTemp = new AccommodationDTO();
            accTemp = acc.Result.addAccommodationResponse.AccommodationDTO;
            
            Accommodation accommodation = accTemp.CreateAccommodation();

            _context.Accommodations.Add(accommodation);
            _context.SaveChanges();

            return Ok(accTemp);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Accommodation>> GetAccommodations()
        {
            return _context.Accommodations;
        }

        [HttpGet("{id}")]
        public ActionResult<Accommodation> GetAccommodation(long id)
        {
            var acc = _context.Accommodations.Find(id);

            if(acc == null)
            {
                return NotFound();
            }
            return acc;
        }

        [HttpPut("{id}")]
        public ActionResult PutAccommodation(long id, Accommodation acc)
        {
            if(id != acc.Id)
            {
                return BadRequest();
            }

            _context.Entry(acc).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Accommodation> DeleteAccommodation(long id)
        {
            var acc = _context.Accommodations.Find(id);
            if(acc == null)
            {
                return NotFound();
            }

            _context.Accommodations.Remove(acc);
            _context.SaveChanges();

            return acc;
        }
    }
}
