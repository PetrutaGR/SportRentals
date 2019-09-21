using SportRentals.Models;
using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class UserRepository
    {
        private Models.DBObjects.SportRentalsDataContext dbContext;

        public UserRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();
        }

        public UserRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string GetUserID(string userName)
        {
            var user = dbContext.AspNetUsers.FirstOrDefault(x => x.UserName == userName);

            return user.Id;
        }

        public AspNetUser GetUser(string userName)
        {
            return dbContext.AspNetUsers.FirstOrDefault(x => x.UserName == userName);
        }

    }
}