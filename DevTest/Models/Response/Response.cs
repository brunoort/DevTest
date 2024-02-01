using System;
namespace DevTest.Models.Response
{
	public class Response : BaseResponse
	{
		public dynamic Data { get; private set; }

		public Response()
		{

		}

		public Response(dynamic data)
		{
			this.Data = data;
		} 
	}
}

