using System;
namespace api_app.Logging
{
	public class Logging: ILogging
    {
		 

        void ILogging.log(string message, string type)
        {
            if (type=="error")
            {
                Console.WriteLine("Error:- " + message);

            }
            else
            {
                {
                    Console.WriteLine( message);

                }
            }
        }
    }
}

