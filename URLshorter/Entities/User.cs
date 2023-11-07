using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using URLshorter.Data.Rol;

namespace URLshorter.Entities
{
	public class User
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
		public string Email { get; set; }
		public string Pass { get; set; }
		public Rol Rol { get; set; } = Rol.User;
        public User()
        {
        }

    }
}

