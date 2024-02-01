using System;
namespace DevTest.Models.Response
{
	public class RegisterUserResponse
	{
        public string Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}

