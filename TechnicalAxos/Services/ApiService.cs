
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalAxos.Models;

namespace IsacMobile.Services
{
    public class ApiService
    {
        public static String baseUrl = "https://restcountries.com/v3.1";

        private static IApi _api;
        private static IApi Api //singleton implementation
        {
            get
            {
                if (_api == null)
                {
                    var settings = new RefitSettings(new NewtonsoftJsonContentSerializer());

                    _api = RestService.For<IApi>(baseUrl,settings);
                    
                    return _api;
                }
                else
                {
                    return _api;
                }
            }
            
        }
        
        public static async Task<List<Country>> GetCountries()
        {
            try
            {
                var response = await Api.GetCountries();
                return response;
            }
            catch (ApiException e)
            {
               
                throw e;
            }
        }
    }
}
