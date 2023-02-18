using Project.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.Services
{
    public class RateService : IRateService
    {
        /*public async Task<IEnumerable<Rate>> GetRates(DateTime date)
        {
            IEnumerable<Rate> data = await GetAllData(date);
            return data.Where(r => r.Cur_Abbreviation == "RUB" || r.Cur_Abbreviation == "EUR" || r.Cur_Abbreviation == "EUR" || r.Cur_Abbreviation == "EUR" || r.Cur_Abbreviation == "EUR" || r.Cur_Abbreviation == "EUR");

        }


        private async Task<IEnumerable<Rate>> GetAllData(DateTime date) 
        {
            var client = new HttpClient();

            var message = new HttpRequestMessage(HttpMethod.Get, $"https://www.nbrb.by/api/exrates/rates?ondate={date:yyyy-MM-dd}&periodicity=0"); 
            message.Headers.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Accept
            //.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(message);
            if (!response.IsSuccessStatusCode) throw new Exception("GET API ERROR!");

            StreamReader streamReader = new StreamReader(response.Content.ReadAsStream());

            return JsonSerializer.Deserialize<IEnumerable<Rate>>(
                                                     streamReader.ReadToEnd()); ;
        }
*/


    }
}
