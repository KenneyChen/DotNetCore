using System;
using System.Collections.Generic;
using System.Text;

namespace Hello.Services.Impl
{
    public class UserService : IUserService
    {
        public void GetMenu()
        {
            Console.WriteLine("获取到用户菜单");
        }
    }
}
