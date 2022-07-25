using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserDto> Adduser(RegisterUserDto userdto);
        Task<string> GenerateJwt(LoginDto logindto);
        Task<UserDto> GetUserById(Guid id);
    }
}
