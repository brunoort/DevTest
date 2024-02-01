using System;
using DevTest.Models;
using DevTest.Shared;
using DevTest.Interfaces;
using RestSharp;
using DevTest.Models.Response;
using Newtonsoft.Json;
using System.Net;

namespace DevTest.Services
{
	public class UserService : IUserService
    {
        private IConfiguration _configuration;

        public UserService(IConfiguration configuration)
		{
            _configuration = configuration;
        }

		public async Task<RegisterUserResponse> RegisterUser(string email, string password)
		{ 
            // Create a new RestSharp request
            var request = new RestRequest("/Auth/RegisterUser", Method.Post);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            var jsonBody = JsonConvert.SerializeObject(new User()
            {
                email = email,
                passwordHash = password
            });

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));

            request.AddBody(jsonBody);

            var response = await client.ExecuteAsync(request);

            RegisterUserResponse userResult = null;

            if(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                userResult = JsonConvert.DeserializeObject<RegisterUserResponse>(response.Content);
            }

            return userResult;
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            // Create a new RestSharp request
            var request = new RestRequest("/Auth/GetUserByEmail/" + email, Method.Get);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));
             
            var response = await client.ExecuteAsync(request);

            LoginResponse userResult = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                userResult = JsonConvert.DeserializeObject<LoginResponse>(response.Content);
            }

            return userResult;
        }


    }
}

