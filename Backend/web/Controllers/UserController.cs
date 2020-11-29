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
        public ActionResult<LoginResponseModel> Login(LoginModel model)
        {
            var user = _unitOfWork.User.Find(x => x.Id == model.Id && x.Password == model.Password).FirstOrDefault();
            if (user == null)
            {
                return NotFound("Sai tên đăng nhập hoặc mật khẩu");
            }
            var listUserRole = _unitOfWork.UserRole.Find(x => x.UserId == user.Id).ToList();
            List<string> listRoleId = new List<string>();
            foreach (var item in listUserRole)
            {
                var roleName = _unitOfWork.Role.Find(x => x.Id == item.RoleId).FirstOrDefault().Name;
                listRoleId.Add(roleName);

            }
            var token = _jWTService.GenerateToken(user.Id, user.FullName, listRoleId);
            return token;
        }

    }
}