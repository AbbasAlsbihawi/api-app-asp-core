using System;
using Microsoft.EntityFrameworkCore;

namespace api_app.models
{
	public class User
	{
		
		public int Id { get; set; }
        public required string UserName { get; set; }
	}
  
}

