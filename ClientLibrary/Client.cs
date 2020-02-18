using ClientLibrary.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClientLibrary
{
    public class Client
    {
        private string Token { get; set; }

        private const string BASE_URI = "https://sportsapi.azurewebsites.net/api/";
        private const string AUTHENTICATION_URI = "Authentication/Authenticate";
        private const string TENNIS_PLAYER_BY_ID = "TennisPlayerById/{0}";
        private const string TENNIS_PLAYER_BY_NAME = "TennisPlayersByName/{0}";
        private const string TENNIS_PLAYER_MATCHES_BY_ID = "TennisPlayerMatchesById/{0}";
        private const string TENNIS_LIVE_SCORES = "TennisLiveScores";

        public Client(string username, string password)
        {
            Authenticate(username, password);
        }
        private void Authenticate(string username, string password)
        {
            var authRequest = new Authenticate
            {
                Username = username,
                Password = password
            };

            using (var client = new HttpClient())
            {
                var uri = $"{BASE_URI}{AUTHENTICATION_URI}";

                var content = new StringContent(JsonConvert.SerializeObject(authRequest));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = client.PostAsync(uri, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Token = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    var responseMessage = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(responseMessage);
                }
            }
        }
        public TennisPlayer GetTennisPlayerById(string id)
        {
            var query = string.Format($"{BASE_URI}{TENNIS_PLAYER_BY_ID}", id);
            return GetApiResponse<TennisPlayer>(query);
        }
        public List<TennisPlayer> GetTennisPlayersByName(string name)
        {
            var query = string.Format($"{BASE_URI}{TENNIS_PLAYER_BY_NAME}", name);
            return GetApiResponse<List<TennisPlayer>>(query);
        }
        public List<TennisMatch> GetTennisPlayerMatchesById(string id)
        {
            var query = string.Format($"{BASE_URI}{TENNIS_PLAYER_MATCHES_BY_ID}", id);
            return GetApiResponse<List<TennisMatch>>(query);
        }
        public List<TennisLiveScore> GetTennisLiveScores()
        {
            var query = $"{BASE_URI}{TENNIS_LIVE_SCORES}";
            return GetApiResponse<List<TennisLiveScore>>(query);
        }
        private T GetApiResponse<T>(string query)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Token);

                var result = client.GetStringAsync(query).Result;
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
