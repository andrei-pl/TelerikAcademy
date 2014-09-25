using BullsAndCows.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BullsAndCows.Web.Controllers
{
    [Authorize]
    public abstract class BaseApiController : ApiController
    {
        protected IBullsAndCowsData data;

        public BaseApiController() : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public BaseApiController(IBullsAndCowsData data)
        {
            this.data = data;
        }
    }
}
