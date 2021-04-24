﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webBuy_with_Rest_API.Models;

namespace webBuy_with_Rest_API.Repositories
{
    public class UserRepository : Repository<User>
    {
        public User VerifyLogin(string email, string password)
        {
            return this.context.Users.Where(e => e.email == email).Where(p => p.password == password).FirstOrDefault();
        }
        public bool VerifyEmailInDb(string email)
        {
            var user=this.context.Users.Where(e => e.email == email).FirstOrDefault();
            if (user==null)
            {
                return true;
            }
            return false;
        }
        public List<User> GetBannedUsers()
        {
            return this.context.Users.Where(e => e.userStatus == 0).ToList();
        }
    }
}