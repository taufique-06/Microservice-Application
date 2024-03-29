﻿using PlatformService.DTOs;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDTO platformReadDTO)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(platformReadDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_configuration["CommandServiceURL"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync POST to CommandService was okay");
            }
            else
            {
                Console.WriteLine("Sync POST to CommandService was not okay");
            }
        }
    }
}