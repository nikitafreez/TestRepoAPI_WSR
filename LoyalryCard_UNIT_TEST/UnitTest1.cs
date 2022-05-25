using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Session2_API_CORE;
using Session2_API_CORE.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LoyalryCard_UNIT_TEST
{
    public class Tests
    {
        private readonly WebApplicationFactory<Startup> _application;
        private readonly HttpClient _client;

        public Tests()
        {
            _application = new();
            _client = _application.CreateClient();
        }

        [Test]
        public async Task TestGetLoyaltyCards()
        {
            var result = await _client.GetFromJsonAsync<List<LoyaltyCard>>("/api/LoyaltyCard");
            Assert.NotNull(result);
        }

        [Test]
        public async Task TestGetCameraLoads()
        {
            var result = await _client.GetFromJsonAsync<List<CameraLoad>>("/api/CameraLoads");
            Assert.NotNull(result);
        }
    }
}