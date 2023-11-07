using System;
using URLshorter.Entities;
using URLshorter.Models;

namespace URLshorter.Services.Interfaces
{
	public interface IUserService
	{
        User ValidateUser(AuthenticationRequestDto authRequestBody);
    }
}

