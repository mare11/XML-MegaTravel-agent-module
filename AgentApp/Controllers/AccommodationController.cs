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

        public AccommodationController(AgentContext context)
        {
            _context = context;

        }

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

            // attach type in context so it doesn't get saved in database again and check the same for location
            _context.AccommodationTypes.Attach(accommodation.AccommodationType);

            if (_context.Locations.Any(loc => loc.Id == accommodation.Location.Id))
            {
                _context.Locations.Attach(accommodation.Location);
            }

            _context.Accommodations.Add(accommodation);
            _context.SaveChanges();

            return Ok(accTemp);
        }

        public ActionResult<IEnumerable<Accommodation>> GetAccommodations()
        { 

            return _context.Accommodations
                .Include(accommodation => accommodation.AdditionalServices)
                .Include(accommodation => accommodation.AccommodationType)
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
                .Include(accommodation => accommodation.AccommodationType)
                .Include(accommodation => accommodation.Unavailabilities)
                .Include(accommodation => accommodation.PeriodPrices)
                .FirstOrDefault(accommodation => accommodation.Id == id);

            if (acc == null)
            {
                return NotFound();
            }

            return acc;
        }

        [HttpPut]
        public ActionResult UpdateAccommodation(Accommodation acc)
        {

            var oldAcc = _context.Accommodations
                        .Include(accommodation => accommodation.AdditionalServices)
                        .Include(accommodation => accommodation.Location)
                        .Include(accommodation => accommodation.AccommodationType)
                        .Include(accommodation => accommodation.Unavailabilities)
                        .Include(accommodation => accommodation.PeriodPrices)
                        .FirstOrDefault(accommodation => accommodation.Id == acc.Id);

            if (oldAcc == null)
            {
                return NotFound();
            }

            AccommodationPortClient accPortClient = new AccommodationPortClient();
            updateAccommodationRequest accRequest = new updateAccommodationRequest();

            AccommodationDTO accDTO = new AccommodationDTO(acc);
            List<AccommodationService.AdditionalService> ads = new List<AccommodationService.AdditionalService>();
            for (int i = 0; i < acc.AdditionalServices.Count; ++i)
            {
                AgentDB.Models.AdditionalServicesOnly additionalService = _context.AdditionalServicesOnlies.FirstOrDefault(addServ => addServ.AdditionalServiceName == acc.AdditionalServices[i].AdditionalServiceName);
                AccommodationService.AdditionalService addService = new AccommodationService.AdditionalService();
                addService.id = additionalService.Id;
                addService.additionalServiceName = additionalService.AdditionalServiceName;
                ads.Add(addService);
            }

            accDTO.additionalServices = ads.ToArray();

            accRequest.AccommodationDTO = accDTO;

            var accUpdate = accPortClient.updateAccommodationAsync(accRequest);
            accUpdate.Wait();

            // update accommodation details
            _context.Entry(oldAcc).CurrentValues.SetValues(acc);

            // delete old services
            foreach(var oldServ in oldAcc.AdditionalServices.ToList())
            {
                bool found = false;
                if (acc.AdditionalServices.Any(s => s.AdditionalServiceName == oldServ.AdditionalServiceName))
                {
                    found = true;
                }

                if (!found)
                {
                    oldAcc.AdditionalServices.Remove(oldServ);
                    _context.AdditionalServices.Remove(oldServ);
                }
            }

            // add new services
            foreach(var newServ in acc.AdditionalServices)
            {
                bool found = false;
                if(oldAcc.AdditionalServices.Any(s => s.AdditionalServiceName == newServ.AdditionalServiceName))
                {
                    found = true;
                }
                        
                if (!found)
                {
                    Models.AdditionalService service = new Models.AdditionalService();
                    service.AdditionalServiceName = newServ.AdditionalServiceName;
                    oldAcc.AdditionalServices.Add(service);
                }
            }

            // add new period price
            foreach (var newPeriod in acc.PeriodPrices)
            {
                bool found = false;
                if (oldAcc.PeriodPrices.Any(p => p.Id == newPeriod.Id))
                {
                    found = true;
                }

                if (!found)
                {
                    oldAcc.PeriodPrices.Add(newPeriod);
                }
            }

            // add new unavailability
            foreach(var newUnv in acc.Unavailabilities)
            {
                bool found = false;
                if (oldAcc.Unavailabilities.Any(u => u.Id == newUnv.Id))
                {
                    found = true;
                }

                if (!found)
                {
                    oldAcc.Unavailabilities.Add(newUnv);
                }
            }

            _context.Entry(oldAcc).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(oldAcc);
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
