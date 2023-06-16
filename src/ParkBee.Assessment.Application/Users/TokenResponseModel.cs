using System;
using Newtonsoft.Json;

namespace ParkBee.Assessment.Application.Users
{
    public class TokenResponseModel
    {
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
        
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}