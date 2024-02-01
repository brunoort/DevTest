using System;
namespace DevTest.Models.Response
{
	public enum ResponseStatus
	{
		Success = 200,
		ValidationError = 400,
		InternalError = 500,
		NotFound = 404,
		AuthenticationError = 401
	}
}

