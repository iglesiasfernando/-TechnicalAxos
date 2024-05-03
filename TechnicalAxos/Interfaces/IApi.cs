using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechnicalAxos.Models;

namespace IsacMobile.Services
{
    public interface IApi
    {
        [Get("/all")]
        Task<List<Country>> GetCountries();
 
    }

}
