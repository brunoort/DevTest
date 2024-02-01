using System;
using System.Net;

namespace DevTest.Models.Response
{
	public class BaseResponseApi
	{
		public int Code { get; set; }
        public string Message { get; set; }
        public string Key { get; set; }
        public IEnumerable<string> Details { get; set; }
        public dynamic Data { get; set; }


        public BaseResponseApi(Response responseMediator)
        {
            this.Message = responseMediator.Message;
            this.Key = responseMediator.Key.ToString();
            this.Data = responseMediator.Data;
            this.SetStatusCodeHttp(responseMediator);
        }

        private void SetStatusCodeHttp(Response responseMediator)
        {
            switch (responseMediator.ResponseStatus)
            {
                case ResponseStatus.Success:
                    this.Code = (int)HttpStatusCode.OK;
                    break;
                case ResponseStatus.ValidationError:
                    this.Code = (int)HttpStatusCode.BadRequest;
                    break;
                case ResponseStatus.InternalError:
                    this.Code = (int)HttpStatusCode.InternalServerError;
                    break;
                case ResponseStatus.NotFound:
                    this.Code = (int)HttpStatusCode.NotFound;
                    break;
                case ResponseStatus.AuthenticationError:
                    this.Code = (int)HttpStatusCode.Unauthorized;
                    break;
                default:
                    break;

            }
        }
    }

}

