using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccommodationService;
using AgentDB;
using Microsoft.AspNetCore.Mvc;

namespace AgentApp.Controllers
{
    public class AdditionalServicesController : ControllerBase
    {
        private readonly AgentContext _context;

        public AdditionalServicesController(AgentContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<AgentDB.Models.AdditionalServicesOnly>> GetAdditionalServices()
        {
            AccommodationPortClient accPortClient = new AccommodationPortClient();
            getAdditionalServicesRequest asRequest = new getAdditionalServicesRequest();

            var addServ = accPortClient.getAdditionalServicesAsync(asRequest);
            addServ.Wait();
            List<AccommodationService.AdditionalService> tempList = addServ.Result.getAdditionalServicesResponse1.ToList();

            //vadim iz lokalne baze sve additionalServices
            List<AgentDB.Models.AdditionalServicesOnly> currentServices = new List<AgentDB.Models.AdditionalServicesOnly>();
            currentServices = _context.AdditionalServicesOnlies.ToList();

            //brisem sve additionalServices iz baze i spremam je za upis novih vrednosti
            if (currentServices != null)
            {
                _context.RemoveRange(currentServices);
                _context.SaveChanges();
            }

            //upis novih vrednosti iz glavne baze(update)
            int n = 0;
            foreach (AccommodationService.AdditionalService addService in tempList)
            {
                _context.AdditionalServices.Add(tempList.ElementAt(n).CreateAdditionalService());
                _context.SaveChanges();
                ++n;
            }

            return _context.AdditionalServicesOnlies;
        }
    }
}