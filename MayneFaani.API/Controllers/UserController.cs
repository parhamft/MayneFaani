using Domain.Core.App.Users.AppServices;
using Domain.Core.App.Users.Entity;
using Infra.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace MayneFaani.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost("login")]
        public User Login(string NationalCode, string password)
        {
            try
            {
                OnlineUser.CurrentUser = _userAppService.Login(NationalCode, password);
            }
            catch (Exception ex)
            {
                return null;
            }
            return OnlineUser.CurrentUser;
        }

        [HttpPost("Register")]
        public void Register(string nationalcode, string password, string phoneNumber, string Address)
        {
            try
            {
                _userAppService.Register(nationalcode, password, phoneNumber, Address);

            }

            catch (Exception ex)
            {

            }
        }
        [HttpGet("logOut")]
        public void LogOut()
        {
            OnlineUser.CurrentUser = null;

        }
    }
}
