using SWP.BLL.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.BLL.IService
{
    public interface IAuthService
    {
        LoginResponseDto Login(LoginRequestDto request);
    }
}
