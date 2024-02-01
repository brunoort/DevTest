using System;
namespace DevTest.Models.Response
{
	public abstract class BaseResponse
	{
		public BaseResponse()
		{
			ResponseStatus = ResponseStatus.Success;
			this.Key = Guid.NewGuid();
		}

		public Guid Key { get; private set; }
        public ResponseStatus ResponseStatus { get; private set; }
        public string Message { get; private set; }

		public void SetSucess() { 
			this.ResponseStatus = ResponseStatus.Success;
			this.Message = "OK";
        }
    }
}

