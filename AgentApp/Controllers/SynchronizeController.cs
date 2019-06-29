using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgentApp.Models;
using AgentDB;
using AccommodationService;
using ReservationService;
using AgentDB.Models;

namespace AgentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SynchronizeController : ControllerBase
    {
        private readonly AgentContext _context;
        public SynchronizeController(AgentContext context) => _context = context;

        [HttpPost("{id}")]
        public ActionResult Login(long id)
        {
            //*** ACCOMMODATIONTYPES ***//
            AccommodationPortClient accPortClient = new AccommodationPortClient();
            getAccommodationTypesRequest atRequest = new getAccommodationTypesRequest();

            var at = accPortClient.getAccommodationTypesAsync(atRequest);
            at.Wait();
            List<AccommodationService.AccommodationType> tempList = at.Result.getAccommodationTypesResponse1.ToList();

            int n = 0;
            foreach (AccommodationService.AccommodationType aType in tempList)
            {
                _context.AccommodationTypes.Add(tempList.ElementAt(n).CreateAccommodationType());
                _context.SaveChanges();
                ++n;
            }

            //*** ADDITIONALSERVICES ***//
            getAdditionalServicesRequest asRequest = new getAdditionalServicesRequest();

            var addServ = accPortClient.getAdditionalServicesAsync(asRequest);
            addServ.Wait();
            List<AccommodationService.AdditionalService> tempListAS = addServ.Result.getAdditionalServicesResponse1.ToList();

            int k = 0;
            foreach (AccommodationService.AdditionalService addService in tempListAS)
            {
                AdditionalServicesOnly adso = new AdditionalServicesOnly();
                adso.Id = addService.id;
                adso.AdditionalServiceName = addService.additionalServiceName;

                _context.AdditionalServicesOnlies.Add(adso);
                _context.SaveChanges();
                ++k;
            }

            //*** ACCOMMODATION ***//
            getAccommodationRequest getAccommodationRequest = new getAccommodationRequest();
            getAccommodationRequest.id = id;

            var addAcc = accPortClient.getAccommodationAsync(getAccommodationRequest);
            addAcc.Wait();
            List<AccommodationService.AccommodationDTO> tempAccommodations = addAcc.Result.getAccommodationResponse.AccommodationDTO.ToList();

            int a = 0;
            foreach(AccommodationService.AccommodationDTO acc in tempAccommodations)
            {
                _context.Accommodations.Add(tempAccommodations.ElementAt(a).CreateAccommodation());
                _context.SaveChanges();
                ++a;
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult Logout()
        {
            _context.RemoveRange(_context.AdditionalServicesOnlies);
            _context.RemoveRange(_context.AdditionalServices);
            _context.RemoveRange(_context.PeriodPrices);
            _context.RemoveRange(_context.Unavailabilities);
            _context.RemoveRange(_context.Messages);
            _context.RemoveRange(_context.Reservations);
            _context.RemoveRange(_context.ReservationRatings);
            _context.RemoveRange(_context.Accommodations);
            _context.RemoveRange(_context.AccommodationTypes);
            _context.RemoveRange(_context.Agents);
            _context.RemoveRange(_context.Locations);

            _context.SaveChanges();

            return Ok();
        }


    }
}
