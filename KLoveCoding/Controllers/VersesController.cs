using KLoveCoding.Service.Dtos;
using KLoveCoding.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KLoveCoding.Controllers
{
    public class VersesController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Search(SearchViewModel searchViewModel)
        {
            if (searchViewModel.NumberOfVerses > 0 && searchViewModel.StartDate != DateTime.MinValue)
            {
                var httpClient = new HttpClient();    

                //These settings will come from the app config
                string kLoveVerseAPI = KLoveCoding.Service.Common.ConfigService.Get("KLoveSettings:APIURL");
                int maximumVerses = Convert.ToInt32(KLoveCoding.Service.Common.ConfigService.Get("KLoveSettings:MaximumVerses"));

                //If a user tries to request too many verses, stop them at the maximum setting
                int numberOfVerses = searchViewModel.NumberOfVerses.Value > maximumVerses ? maximumVerses : searchViewModel.NumberOfVerses.Value;
                    
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

                queryString.Add("siteId", "1");
                queryString.Add("startDate", searchViewModel.StartDate.Value.ToString("yyyy-MM-dd"));
                queryString.Add("pageSize", numberOfVerses.ToString());

                string finalAPI = kLoveVerseAPI + queryString;

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(finalAPI));

                string KLOVEAPIKEY = Environment.GetEnvironmentVariable("KLOVEAPIKEY");

                request.Headers.Authorization = new AuthenticationHeaderValue("Ocp-Apim-Subscription-Key", KLOVEAPIKEY);
                HttpResponseMessage response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    VerseResultRootDto verseResultRootDto = Newtonsoft.Json.JsonConvert.DeserializeObject<VerseResultRootDto>(responseBody);

                    searchViewModel.VerseResultRootDto = verseResultRootDto;
                }
            }            

            return View(searchViewModel);
        }
    }
}