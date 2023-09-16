using System;
namespace api_app.Logging
{
	public interface ILogging
	{
        public void log(string message, string type);
    }
}

