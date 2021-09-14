using DataAccess.Admin;
using DataAccess.Helper;
using DataAccess.Models;
using DataAccess.Models.TheModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.UserBussinessLayer
{
    public class UseRepository : IUsers
    {
        TestingContext _db = new TestingContext();
        private string connectionstring;


        public async Task<ResponseHelper> CreateProfile(Register register)
        {
            var response = new ResponseHelper();
            response.IsSucesss = false;
            if (!string.IsNullOrEmpty(register.Email) && !string.IsNullOrEmpty(register.Password))
            {
                var getUser = (from s in _db.Users where s.Email == register.Email select s).FirstOrDefault();
                if (getUser == null)
                {
                    using (TestingContext _db = new TestingContext())
                    {
                        await _db.Users.AddAsync(GenerateRegisterUser(register));
                        await _db.SaveChangesAsync();
                    }
                    response.IsSucesss = true;
                    return response;
                }
                response.Message = "Email address already exist";
                return response;              
            }
            response.Message = "Email Address or Password is empty";
            return response;            
        }


        public async Task<IEnumerable<object>> GetUsers()
        {
            return _db.Users.ToList();

        }
        public async Task<IEnumerable<object>> GetUser(int userId)
        {
             return   _db.Users.Where(u => u.Id == userId);

        }


        public async Task<IEnumerable<object>> GetRoles()
        {
            var userList = _db.Roles.ToList();
            return userList;

        }
        public async Task<IEnumerable<object>> GetDepartments()
        {
            
             var userList  =  _db.Departments.ToList();
            return  userList;

        }
        public async Task<IEnumerable<object>> GetCities()
        {
            var userList = _db.Cities.ToList();
            return userList;


        }



       private User GenerateRegisterUser(Register register)
        {
            var KeyNew = BLSecurity.GeneratePassword(10);
            var password = BLSecurity.EncodePassword(register.Password, KeyNew);
            register.Password = password;
            register.VerificationCode = KeyNew;
            return new User
            {
                AdminName = register.AdminName,
                Email = register.Email,
                Password = register.Password,
                FkCityId = register.CityID,
                FkDepartmentId = register.DepartmentID,
                VerificationCode = register.VerificationCode,
                FkRoleId = register.RoleID
            };
        }

    }
}
