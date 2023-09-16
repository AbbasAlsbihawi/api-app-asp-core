using System;
using System.Collections;
using System.Collections.Generic;
using api_app.models.DTO;

namespace api_app.Data
{
	public class UserStore
    {
		public static List<UserDTO> listUser = new List<UserDTO> {
                new UserDTO{Id=1,UserName="abbas",firstname="abbas",lastname="alsbihawi" },
                  new UserDTO{Id=2,UserName="ali",firstname="ali",lastname="alsbihawi" },
            };
    }
}

