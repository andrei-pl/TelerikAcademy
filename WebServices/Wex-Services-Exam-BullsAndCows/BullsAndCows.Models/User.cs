namespace BullsAndCows.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        //private ICollection<Game> games;

        //[Required]
        //[Range(4, 4)]
        //public int Number { get; set; }

        //public virtual ICollection<Game> Games
        //{
        //    get
        //    {
        //        return this.games;
        //    }
        //    set
        //    {
        //        this.games = value;
        //    }
        //}

        //public User()
        //{
        //    this.games = new HashSet<Game>();
        //    this.Number = GenerateNumberWithNonRepeatDigits();
        //}

        //private int GenerateNumberWithNonRepeatDigits()
        //{
        //    int number = 0;
        //    Random rand = new Random();
        //    bool isNumberReady = false;

        //    while (!isNumberReady)
        //    {
        //        number = rand.Next(1023, 9877);
        //        var numberAsString = number.ToString();
        //        bool isNonRepeatNumber = true;

        //        for (int i = 0; i < 4; i++)
        //        {
        //            for (int j = i + 1; j < 4; j++)
        //            {
        //                if (numberAsString[j] == numberAsString[i])
        //                {
        //                    isNonRepeatNumber = false;
        //                    break;
        //                }
        //            }

        //            if (!isNonRepeatNumber)
        //            {
        //                break;
        //            }
        //            if(i == 3)
        //            {
        //                isNumberReady = true;
        //            }
        //        }
        //    }

        //    return number;
        //}
    }
}
