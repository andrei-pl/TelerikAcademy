namespace BullsAndCows.Web.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading;

    using Microsoft.AspNet.Identity;


    public class AspNetUserIdProvider : BullsAndCows.Web.Infrastructure.IUserIdProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}