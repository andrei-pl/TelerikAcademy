using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using BullsAndCows.Data;
using BullsAndCows.Models;
namespace BullsAndCows.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BullsAndCowsData db = new BullsAndCowsData(new BullsAndCowsDbContext());
            db.Users.Add(new User());
            db.SaveChanges();
        }
    }
}
