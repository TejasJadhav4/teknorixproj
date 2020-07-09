using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknorixWebApplication.Models;

namespace TeknorixWebApplication.Interface
{
    interface IUserService
    {
        List<UserModel> GetList();

        int SaveUser(UserModel Model);

        UserModel UserDetailById(int UserId);
    }
}
