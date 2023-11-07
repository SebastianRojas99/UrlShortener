using System;
using URLshorter.Entities;
using URLshorter.Models;
using URLshorter.Services.Interfaces;

namespace URLshorter.Services.Implementations
{
	public class UserService : IUserService
    {
        private readonly URLshorterContext _context;
        public UserService(URLshorterContext context)
        {
            _context = context;
        }

        public User? ValidateUser(AuthenticationRequestDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Pass == authRequestBody.Pass);
        }
        
	}
}

