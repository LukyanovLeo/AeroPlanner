using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using AeroPlanner.Contexts;
using Microsoft.AspNetCore.Authorization;
using AeroPlanner.Models.Responses;
using AeroPlanner.Models.Requests;

namespace AeroPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IDbContext _dbContext;

        public UserController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("addNewUser")]
        public AddNewUserResponse AddNewUser([FromBody] AddNewUserRequest request)
        {
            return new AddNewUserResponse(_dbContext.UsersRepository.AddNewUser(request));
        }
    }
}
