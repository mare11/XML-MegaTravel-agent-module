using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccommodationService;
using AgentDB;
using Microsoft.AspNetCore.Mvc;

namespace AgentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            //if (currentServices != null)
            //{
            //    _context.RemoveRange(currentServices);
            //    _context.SaveChanges();
            //}

            //upis novih vrednosti iz glavne baze(update)
            for (int i = 0; i < tempList.Count; ++i)
            {
                AdditionalService addService = tempList[i];
                bool flag = false;
                for (int j = 0; j < currentServices.Count; ++j)
                {
                    if (tempList.ElementAt(i).id == currentServices.ElementAt(j).Id)
                    {
                        currentServices.RemoveAt(j);
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                AgentDB.Models.AdditionalServicesOnly only = new AgentDB.Models.AdditionalServicesOnly();
                only.Id = addService.id;
                only.AdditionalServiceName = addService.additionalServiceName;
                _context.AdditionalServicesOnlies.Add(only);
                _context.SaveChanges();
                }
            }

            if (currentServices.Count > 0)
            {
                for (int i = 0; i < currentServices.Count; ++i)
                {
                    _context.AdditionalServicesOnlies.Remove(currentServices.ElementAt(i));
                    _context.SaveChanges();
                }
            }

            return _context.AdditionalServicesOnlies;
        }
    }
}