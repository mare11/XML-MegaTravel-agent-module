using AccommodationService;
using AgentApp.Models;
using AgentDB;
using AutoMapper;
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

        public AccommodationController(AgentContext context, IMapper mapper)
        {
            _context = context;

        }

        [HttpPost] //izbrisi id posle testiranja
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


        //nije implrementiran servis za ovo u glavnom backend-u
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Accommodation>> GetAccommodations(long id)
        { 

            return _context.Accommodations
                .Include(accommodation => accommodation.AdditionalServices)
                .Include(accommodation => accommodation.AccommodationTypeField)
                .Include(accommodation => accommodation.Location)
                .Include(accommodation => accommodation.Unavailabilities)
                .Include(accommodation => accommodation.PeriodPrices).ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Accommodation> GetAccommodation(long id)
        {
            var acc = _context.Accommodations
                .Include(accommodation => accommodation.AdditionalServices)
                .Include(accommodation => accommodation.Location)
                .Include(accommodation => accommodation.AccommodationTypeField)
                .Include(accommodation => accommodation.Unavailabilities)
                .Include(accommodation => accommodation.PeriodPrices)
                .FirstOrDefault(accommodation => accommodation.Id == id);

            if (acc == null)
            {
                return NotFound();
            }

            return acc;
        }

        [HttpPut("{id}")]
        public ActionResult PutAccommodation(Accommodation acc)
        {
            AccommodationPortClient accPortClient = new AccommodationPortClient();
            updateAccommodationRequest accRequest = new updateAccommodationRequest();

            AccommodationDTO accDTO = new AccommodationDTO(acc);
            List<AccommodationService.AdditionalService> ads = new List<AccommodationService.AdditionalService>();
            for(int i = 0; i < acc.AdditionalServices.Count; ++i)
            {
                AgentDB.Models.AdditionalServicesOnly additionalService = _context.AdditionalServicesOnlies.FirstOrDefault(addServ => addServ.AdditionalServiceName == acc.AdditionalServices[i].AdditionalServiceName);
                AccommodationService.AdditionalService addService = new AccommodationService.AdditionalService();
                addService.Id = additionalService.Id;
                addService.additionalServiceName = additionalService.AdditionalServiceName;
                ads.Add(addService);
            }

            accDTO.AdditionalService = ads.ToArray();

            accRequest.AccommodationDTO = accDTO;

            _context.Entry(acc).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //[HttpDelete("{id}")] //obezbediti delete za web servis
        //public ActionResult<Accommodation> DeleteAccommodation(long id)
        //{
        //    var acc = _context.Accommodations.Find(id);
        //    if (acc == null)
        //    {
        //        return NotFound();
        //    }

        //    AccommodationPortClient accPortClient = new AccommodationPortClient();
        //    deleteAccommodationRequest accRequest = new deleteAccommodationRequest();

        //    accRequest.id = id;

        //    var accTemp = accPortClient.deleteAccommodationAsync(accRequest);
        //    accTemp.Wait();

        //    var response = accTemp.Result.deleteAccommodationResponse.flag;

        //    if(response == true)
        //    {
        //        _context.Accommodations.Remove(acc);
        //        _context.SaveChanges();

        //        return acc;
        //    }

        //    return NotFound();
        //}
    }
}
