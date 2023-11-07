using System;
using URLshorter.Data.Rol;

namespace URLshorter.Models
{
	public class UserForCreationsDTO
	{
		public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Pass { get; set; }
        public Rol Rol { get; set; }
    }
}

