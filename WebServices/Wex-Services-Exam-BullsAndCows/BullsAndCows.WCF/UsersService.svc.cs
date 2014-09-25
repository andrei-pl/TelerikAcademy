using BullsAndCows.Data;
using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BullsAndCows.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsersService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsersService.svc or UsersService.svc.cs at the Solution Explorer and start debugging.
    public class UsersService : IUsersService
    {
        BullsAndCowsData data = new BullsAndCowsData(new BullsAndCowsDbContext());

        public IEnumerable<User> ReturnFirst10Users()
        {
            return ReturnFirst10Users(0);
        }

        public IEnumerable<User> ReturnFirst10Users(int page)
        {
            var users = this.data.Users.All()
                .Skip(page * 10)
                .Take(10)
                .ToList();

            return users;
        }

        public User ReturnUserById(int id)
        {
            var user = this.data.Users.Find(id);

            return user;
        }
    }
}
