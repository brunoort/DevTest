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
	public class AuthorService : IAuthorService
    {
        private IConfiguration _configuration;

        public AuthorService(IConfiguration configuration)
		{
            _configuration = configuration;
        }

        public async Task<List<AuthorListResponse>> GetAll()
        {
            // Create a new RestSharp request
            var request = new RestRequest("/Author/GetAll", Method.Get);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));
             
            var response = await client.ExecuteAsync(request);

            List<AuthorListResponse> responseObj = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseObj = JsonConvert.DeserializeObject<List<AuthorListResponse>>(response.Content);
            }

            return responseObj;
        }


        public async Task<AuthorListResponse> GetById(string id)
        {
            // Create a new RestSharp request
            var request = new RestRequest("/Author/Get/" + id, Method.Get);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));

            var response = await client.ExecuteAsync(request);

            AuthorListResponse responseObj = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseObj = JsonConvert.DeserializeObject<AuthorListResponse>(response.Content);
            }

            return responseObj;
        }

        public async Task<AuthorListResponse> Update(AuthorListResponse author)
        {
            // Create a new RestSharp request
            var request = new RestRequest("/Author/Edit", Method.Post);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));
             
            request.AddBody(author);
             
            var response = await client.ExecuteAsync(request);

            AuthorListResponse responseObj = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseObj = JsonConvert.DeserializeObject<AuthorListResponse>(response.Content);
            }

            return responseObj;
        }

        public async Task<AuthorListResponse> Create(AuthorCreate author)
        {
            // Create a new RestSharp request
            var request = new RestRequest("/Author/Add", Method.Post);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));
             
            request.AddBody(author);

            var response = await client.ExecuteAsync(request);

            AuthorListResponse responseObj = null;

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                responseObj = JsonConvert.DeserializeObject<AuthorListResponse>(response.Content);
            }

            return responseObj;
        }
    }
}

