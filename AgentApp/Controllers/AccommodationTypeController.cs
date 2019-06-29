using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccommodationService;
using AgentApp.Models;
using AgentDB;
using Microsoft.AspNetCore.Mvc;

namespace AgentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationTypeController : ControllerBase
    {
        private readonly AgentContext _context;

        public AccommodationTypeController(AgentContext context) => _context = context;


        [HttpGet]
        public ActionResult<IEnumerable<Models.AccommodationType>> GetAccommodationTypes()
        {
            AccommodationPortClient atPortClient = new AccommodationPortClient();
            getAccommodationTypesRequest atRequest = new getAccommodationTypesRequest();

            var at = atPortClient.getAccommodationTypesAsync(atRequest);
            at.Wait();
            List<AccommodationService.AccommodationType> tempList = at.Result.getAccommodationTypesResponse1.ToList();

            //vadim iz lokalne baze sve accommodationTypes
            List<Models.AccommodationType> currentTypes = new List<Models.AccommodationType>();
            currentTypes = _context.AccommodationTypes.ToList();

            for(int i = 0; i < tempList.Count; ++i)
            {
                Models.AccommodationType accType = tempList[i].CreateAccommodationType();
                bool flag = false;
                for(int j = 0; j < currentTypes.Count; ++j)
                {
                    if(tempList.ElementAt(i).id == currentTypes.ElementAt(j).Id)
                    {
                        currentTypes.RemoveAt(j);
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    _context.AccommodationTypes.Add(accType);
                    _context.SaveChanges();
                }
            }

            if(currentTypes.Count > 0)
            {
                for( int i = 0; i < currentTypes.Count; ++i)
                {
                    _context.AccommodationTypes.Remove(currentTypes.ElementAt(i));
                    _context.SaveChanges();
                }
            }
            
            ////upis novih vrednosti iz glavne baze(update)
            //int n = 0;
            //foreach (AccommodationService.AccommodationType aType in tempList)
            //{
            //    _context.AccommodationTypes.Add(tempList.ElementAt(n).CreateAccommodationType());
            //    _context.SaveChanges();
            //    ++n;
            //}

            return _context.AccommodationTypes;
        }
       
    }
}