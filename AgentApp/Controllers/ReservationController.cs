using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApp.Models;
using AgentDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationService;

namespace AgentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly AgentContext _context;

        public ReservationController(AgentContext context) => _context = context;

        [HttpGet("{id}")] //id smestaja 
        public ActionResult<ReservationService.Reservation[]> GetReservation(long id)
        {
            ReservationPortClient reservationPortClient = new ReservationPortClient();
            getReservationRequest reservationRequest = new getReservationRequest();

            reservationRequest.accommodationId = id;

            var resTemp = reservationPortClient.getReservationAsync(reservationRequest);
            resTemp.Wait();

            ReservationService.Reservation[] reservations = resTemp.Result.getReservationResponse1;

            List<Models.Reservation> ress = new List<Models.Reservation>();
            ress = _context.Reservations
                .Include(reservation => reservation.Messages).ToList();
            ;

            for (int i = 0; i < reservations.Length; ++i)
            {
                bool flag = false;
                Accommodation acc = _context.Accommodations.Find(reservations[i].accommodationId);
                Models.Reservation res = reservations[i].CreateReservation();
                res.Accommodation = acc;

                for(int j = 0; j < ress.Count; ++j)
                {
                    if (reservations[i].id == ress.ElementAt(j).Id)
                    {
                        flag = true;

                        // copy all values
                        _context.Entry(ress.ElementAt(j)).CurrentValues.SetValues(res);

                        // updated messages only if new have arrived
                        if (res.Messages.Count > ress.ElementAt(j).Messages.Count)
                        {
                            // delete all messages
                            foreach (var oldMsg in ress.ElementAt(j).Messages.ToList())
                            {
                                ress.ElementAt(j).Messages.Remove(oldMsg);
                                _context.Messages.Remove(oldMsg);
                            }

                            // add all messages again
                            foreach (var newMsg in res.Messages)
                            {
                                ress.ElementAt(j).Messages.Add(newMsg);
                            }
                        }
                        
                        _context.Entry(ress.ElementAt(j)).State = EntityState.Modified;
                        _context.SaveChanges();
                        ress.RemoveAt(j);
                        break;
                    }
                }

                if(!flag)
                {
                    _context.Reservations.Add(res);
                    _context.SaveChanges();
                }

            }

            if(ress.Count > 0)
            {
                for (int i = 0; i < ress.Count; ++i)
                {
                    _context.Reservations.Remove(ress.ElementAt(i));
                    _context.SaveChanges();
                }
            }

            return reservations;
        }

        [HttpPost("{id}")]
        public ActionResult<ReservationService.Message> AddMessage(ReservationService.Message body, long id)
        {
            Models.Reservation res = _context.Reservations
                .Include(reservation => reservation.Messages)
                .FirstOrDefault(reservation => reservation.Id == id);

            if (res == null)
            {
                return NotFound();
            }

            ReservationPortClient reservationPortClient = new ReservationPortClient();
            addMessageRequest messageRequest = new addMessageRequest();

            messageRequest.reservationId = id;
            messageRequest.Message = body;

            var message = reservationPortClient.addMessageAsync(messageRequest);
            message.Wait();

            if(message.Result.addMessageResponse.Message != null)
            {
                ReservationService.Message msgDTO = message.Result.addMessageResponse.Message;
                Models.Message msg = msgDTO.CreateMessage();

                res.Messages.Add(msg);

                _context.Entry(res).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(msgDTO);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult SetRealized(long id)
        {
            Models.Reservation reservation = _context.Reservations.Find(id);

            if(reservation == null)
            {
                return NotFound();
            }

            ReservationPortClient reservationPortClient = new ReservationPortClient();
            setRealizedRequest realizedRequest = new setRealizedRequest();

            realizedRequest.reservationId = id;

            var response = reservationPortClient.setRealizedAsync(realizedRequest);
            response.Wait();

            if(response.Result.setRealizedResponse.Reservation != null)
            {
                reservation.Realized = response.Result.setRealizedResponse.Reservation.realized;

                _context.Entry(reservation).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
    }
}