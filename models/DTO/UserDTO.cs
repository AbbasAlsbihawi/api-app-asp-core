using System;
using System.ComponentModel.DataAnnotations;

namespace api_app.models.DTO
{
	public class UserDTO
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
        public   string UserName { get; set; }
        public  string firstname { get; set; }
        public  string lastname { get; set; }

    }
}

