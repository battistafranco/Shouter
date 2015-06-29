using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Web.Models;

namespace UI.Web.Services
{
    public class LogOnService
    {
        public static bool CanLogin(string email, string password)
        {
            if (email != "" && password != "")
            {
                MongoDatabase db = DBConnection.Db();
                var users = db.GetCollection("users");
                var query = new QueryDocument("email", email);
                var currentUser = users.FindOne(query);
                if (currentUser["email"] == email && currentUser["password"] == password)
                    return true;
            }
            return false;
        }
    }
}