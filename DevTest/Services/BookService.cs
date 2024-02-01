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
	public class BookService : IBookService
    {
        private IConfiguration _configuration;

        public BookService(IConfiguration configuration)
		{
            _configuration = configuration;
        }

        public async Task<List<BookListResponse>> GetAll()
        {
            // Create a new RestSharp request
            var request = new RestRequest("/Book/GetAll", Method.Get);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));
             
            var response = await client.ExecuteAsync(request);

            List<BookListResponse> responseObj = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseObj = JsonConvert.DeserializeObject<List<BookListResponse>>(response.Content);
            }

            return responseObj;
        }


        public async Task<BookListResponse> GetById(string id)
        {
            // Create a new RestSharp request
            var request = new RestRequest("/Book/Get/" + id, Method.Get);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));

            var response = await client.ExecuteAsync(request);

            BookListResponse responseObj = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseObj = JsonConvert.DeserializeObject<BookListResponse>(response.Content);
            }

            return responseObj;
        }

        public async Task<BookListResponse> Update(BookListResponse author)
        {
            // Create a new RestSharp request
            var request = new RestRequest("/Book/Edit", Method.Post);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));
             
            request.AddBody(author);
             
            var response = await client.ExecuteAsync(request);

            BookListResponse responseObj = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseObj = JsonConvert.DeserializeObject<BookListResponse>(response.Content);
            }

            return responseObj;
        }

        public async Task<BookListResponse> Create(BookCreate book)
        {
            // Create a new RestSharp request
            var request = new RestRequest("/Book/Add", Method.Post);
            string baseUrl = _configuration.GetValue<string>("BaseUrl");
            var client = new RestClient(baseUrl);

            // Add query parameters to the request
            request.AddHeader("API-Key", _configuration.GetValue<string>("ApiKey"));
             
            request.AddBody(book);

            var response = await client.ExecuteAsync(request);

            BookListResponse responseObj = null;

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                responseObj = JsonConvert.DeserializeObject<BookListResponse>(response.Content);
            }

            return responseObj;
        }
    }
}

