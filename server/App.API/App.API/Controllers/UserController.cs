using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using App.API.Models;
using App.API.Services;
using App.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            //When testing, populate the userService var
            if (userService == null)
            {
                //todo
            }
            this.userService = userService;
        }

        [HttpGet]
        [Route("getUsers")]
        public IEnumerable<User> GetUsers(string officeIds)
        {
            //Response _response = new Response();
            List<User> users = new List<User>();
            try
            {
                //Validate the officeIds are null. In case of null return an valid response and an appropiate error message.
                if (officeIds == null)
                    return new List<User>();
                    //    _response = new Response()
                    //{
                    //    Code = HttpStatusCode.BadRequest,
                    //    Message = "officeIds are required"
                    //};


                var ids = officeIds
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(o => Guid.Parse(o))
                        .ToArray();

                users = this.userService.GetUsers()
                    .Where(o => ids.Contains(o.Office.Id))
                    .ToList();

                var roles = this.userService
                    .GetUserRoles(users.Select(o => o.Id).ToArray());


                foreach (var role in roles)
                {
                    var user = users.FirstOrDefault(o => o.Id == role.UserId);
                    if (user is null)
                    {
                        continue;
                    }

                    if (user.Roles is null)
                    {
                        user.Roles = new List<UserRole>();
                    }

                    user.Roles.Add(role);
                }

                //return _response = new Response() { Entities = users, Code = HttpStatusCode.OK};
            }
            //get exception to log what is happening
            catch (Exception ex)
            {
                return new List<User>();
                //return _response = new Response()
                //{
                //    Code = HttpStatusCode.InternalServerError,
                //    Message = ex.Message
                //};
            }
            return users;
        }
    }
}
