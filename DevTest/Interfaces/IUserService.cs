using System;
using DevTest.Models;
using DevTest.Models.Response;
using RestSharp;

namespace DevTest.Interfaces
{
	public interface IUserService
	{
        Task<RegisterUserResponse> RegisterUser(string email, string password);

        Task<LoginResponse> Login(string email, string password);
    }
}

