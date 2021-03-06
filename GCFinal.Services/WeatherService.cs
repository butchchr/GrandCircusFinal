﻿using GCFinal.Domain.Data;
using GCFinal.Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace GCFinal.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IRestClient _client;

        public WeatherService()
        {
            _client = new RestClient(ConfigurationManager.AppSettings["BaseWeatherUri"]);
        }

        public async Task<RootObject> GetHistoricalAsync(string location, DateTime startDate, int duration)
        {
            var beginDate = startDate.ToString("yyyy/MM/dd");
            var endDate = startDate.AddDays(duration - 1).ToString("yyyy/MM/dd");
            var request = new RestRequest(string.Format(ConfigurationManager.AppSettings["WeatherEndpoint"], location, beginDate, endDate), Method.GET);

            var response = await _client.ExecuteTaskAsync(request);

            var data = JsonConvert.DeserializeObject<RootObject>(response.Content);
            return data;
        }

        public async Task<RootObject> GetForecastAsync(string location, int duration)
        {
            var requestNow = new RestRequest(string.Format(ConfigurationManager.AppSettings["WeatherEndpointNow"], location, duration), Method.GET);
            var response = await _client.ExecuteTaskAsync(requestNow);
            var data = JsonConvert.DeserializeObject<RootObject>(response.Content);
            return data;
        }

    }
}
