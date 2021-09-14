using BussinessLayer.UserBussinessLayer;
using DataAccess.Admin;
using DataAccess.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_Project_with_entity_Framework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsers _loginbl;
        
        public LoginController(IUsers loginbl)
        {
            _loginbl = loginbl;
        }

        [Route("InsertUser")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(Register register)
        {
            var res = new ResponseHelper();
            try
            {
                res = await _loginbl.CreateProfile(register);
               return Ok(res);
            }
            catch (Exception e)
            {
                res.Message = e.Message;
                return BadRequest(res);
            }
            //try
            //{
            //    if (register != null)
            //    {
            //        var result = await _loginbl.CreateProfile(register);
            //        if (result != null)
            //        {
            //           return new Response { Status = "Success", Message = "User Registered" };         
            //        }
            //        return new Response { Status = "Failed", Message = "Registration Failed" };
            //    }
            //    return new Response { Status = "Failed", Message = "Registration Failed" };
            //}
            //catch 
            //{
            //    throw;
            //}
        }
        [HttpGet]
        [Route("Users")]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _loginbl.GetUsers());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [Route("Users/{userId}")]
        public async Task<ActionResult> GetUsers(int userId)
        {
            try
            {
                return Ok(await _loginbl.GetUser(userId));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("Roles")]
        public async Task<ActionResult> GetRoles()
        {
            try
            {
                return Ok(await _loginbl.GetRoles());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("City")]
        public async Task<ActionResult> GetCitites()
        {
            try
            {
                return Ok(await _loginbl.GetCities());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("Departments")]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await _loginbl.GetDepartments());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
