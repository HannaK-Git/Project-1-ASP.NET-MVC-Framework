using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstProject.Models
{
    public class LoginBL
    {
        FactoryEntities db = new FactoryEntities();

        public bool CheckUser(string username, string pwd)
        {
            var result = db.Users.Where(x => x.UserName == username && x.Password == pwd).ToList();
            if (result.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public User getUser(String username)
        {
            var result = db.Users.Where(x => x.UserName == username).ToList();
            if (result.Count() == 0)
            {
                return null;
            }
            else
            {
                return result[0] ;
            }
        }


    }
}