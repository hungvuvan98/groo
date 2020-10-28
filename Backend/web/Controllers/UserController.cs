using DAL.Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Infrastructures.Services;
using web.Model;

namespace web.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JWTService _jWTService;

        public UserController(IUnitOfWork unitOfWork, JWTService jWTService)
        {
            _unitOfWork = unitOfWork;
            _jWTService = jWTService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(Login))]
        public ActionResult<LoginResponseModel> Login(string id, string password)
        {
            var user = _unitOfWork.User.Find(x => x.Id == id && x.Password == password).ToList().First();
            if (user == null)
            {
                return NotFound("Account does not exist! ");
            }
            var token = _jWTService.GenerateToken(user.Id, user.FullName, user.Role);
            return token;
        }
    }
}