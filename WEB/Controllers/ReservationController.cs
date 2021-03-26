using BusinessLogic.Interface.Account;
using BusinessLogic.Interface.Reservation;
using Entity.Account;
using Entity.Reservation;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WEB.Controllers
{
    public class ReservationController : Controller
    {
        #region Dependency Injection
        private IKernel kernel = new StandardKernel(new DI.Config.DependencyInjectionContainer());
        private readonly IGetFlightBL _getFlightBL;
        private readonly IGetFlightsBL _getFlightsBL;
        private readonly ISaveUserBL _saveUserBL;
        private readonly ISaveReservationBL _saveReservationBL;
        private readonly IGetUserBL _getUserBL;

        public ReservationController()
        {
            _getFlightsBL = kernel.Get<IGetFlightsBL>();
            _saveUserBL = kernel.Get<ISaveUserBL>();
            _saveReservationBL = kernel.Get<ISaveReservationBL>();
            _getFlightBL = kernel.Get<IGetFlightBL>();
            _getUserBL = kernel.Get<IGetUserBL>();
        }

        #endregion
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewFlight()
        {
            return View();
        }

        //Search Flights
        public Task<string> SearchFlights(string Origin,string Destination,string From)
        {
            return _getFlightsBL.GetFlights(Origin, Destination, From);
        }

        //Make Reservation
        public JsonResult MakeReservation(Flight flight,User user)
        {
            try
            {
                //Get User
                int userId = _saveUserBL.SaveUser(user);
                if (userId == -1)
                {
                    return Json(new { Status = 500, Message = "Error Creating User" });
                }
                //Save Reservation (Flight)
                flight.UserId = userId;
                int flightId = _saveReservationBL.SaveReservation(flight);
                if (flightId == -1)
                {
                    return Json(new { Status = 500, Message = "Error Creating Flight Reservation" });

                }
                return Json(new { Status = 201, Id = flightId });
            }
            catch (Exception e)
            {
                //Log Here
                Console.WriteLine(e);
                return Json(new { Status = 500, Message = "Error Creating Flight Reservation" });
            }

        }
        //Get Flight
        public string GetFlight(int flightId)
        {
            try
            {
                //Get Flight
                Flight flight = _getFlightBL.GetFlight(flightId);
                if (flight == null)
                {
                    return "{\"Status\":500}";
                }
                //Get User
                User user = _getUserBL.GetUser(flight.UserId);
                if (user == null)
                {
                    return "{\"Status\":500}";
                }
                //Return UserFlight
                Object userFlight = new { user = user, flight = flight, date = flight.DepartureDate.Date.ToString("yyyy-MM-dd") };
                string userFlightJson = new JavaScriptSerializer().Serialize(userFlight);
                return userFlightJson;
            }
            catch (Exception e)
            {
                //Log Here
                Console.WriteLine(e);
                return "{\"Status\":500}";

            }
           
        }
    }
}