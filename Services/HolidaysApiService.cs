using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using HolidayApi.Models;

namespace HolidayApi.Services
{
    public class HolidaysApiService : IHolidaysApiService
    {
        private static readonly HttpClient client;

        static HolidaysApiService()
        {
            client = new HttpClient { BaseAddress = new Uri("https://date.nager.at") };
        }

        public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            var url = $"/api/v2/PublicHolidays/{year}/{countryCode}";
            var result = new List<HolidayModel>();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}










