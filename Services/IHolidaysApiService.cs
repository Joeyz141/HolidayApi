using System.Collections.Generic;
using System.Threading.Tasks;
using HolidayApi.Models;

namespace HolidayApi.Services
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHolidays(string countryCode, int year);
    }
}



