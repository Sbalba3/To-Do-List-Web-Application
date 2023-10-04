
using Microsoft.EntityFrameworkCore;
using System;
using To_Do_List_Web_Application.Models;

namespace To_Do_List_Web_Application.Repositry
{
    public class AccountRepositiry : IAccountRepository
    {
        private readonly SysContext sys;

        public AccountRepositiry(SysContext _sys)
        {
            sys= _sys;
        }
        public Users Find(string userName, string password)
        {
            var user = sys.Users.FirstOrDefault(a => a.User_Name == userName && a.Password == password);
            return user;
        }
    }
}
