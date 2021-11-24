using System;


namespace AmanahTask.API.Helpers
{
    public class CustomException : Exception
    {

        public CustomException(string message,int status = 500, Exception innerException = null) : base(message, innerException)
        {
            this.HResult = status;
            //this.StatusCode = 600;
            //      message=   this.Message;


        }
    }
}