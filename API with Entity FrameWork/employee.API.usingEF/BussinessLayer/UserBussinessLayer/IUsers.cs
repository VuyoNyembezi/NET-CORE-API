using DataAccess.Admin;
using DataAccess.Models.TheModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Helper;

namespace BussinessLayer.UserBussinessLayer
{
    public interface IUsers
    {
        Task<ResponseHelper> CreateProfile(Register register);
        Task<IEnumerable<object>> GetUsers();
        Task<IEnumerable<object>> GetUser(int userId);
        Task<IEnumerable<object>> GetDepartments();
        Task<IEnumerable<object>> GetCities();
        Task<IEnumerable<object>> GetRoles();

    }
}
