using Entity.Reservation;
using Infraestructure.Persistence.Repositories.Interface.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Infraestructure.Persistence.Repositories.Implementation.Reservation
{
    public class GetFlightsRepo : IGetFlightsRepo
    {
        private readonly string flightsApi = "http://testapi.vivaair.com/otatest/api/values";
        private static readonly HttpClient client = new HttpClient();


        //Get Flights
        public async Task<string> GetFlights(string Origin, string Destination, string From)
        {
            try
            {
                //Add Parameters To Post
                var data = new Dictionary<string, string>();
                data.Add("Origin", Origin);
                data.Add("Destination", Destination);
                data.Add("From", From);

                //Make Request
                var content = new FormUrlEncodedContent(data);
                var response = await client.PostAsync(flightsApi, content);
                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
            catch (Exception e) 
            {
                //Log Here
                Console.WriteLine(e);

                return "";
            }
           
        }
    }
}
