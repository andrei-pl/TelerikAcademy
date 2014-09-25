namespace BugLogger.RestApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Policy;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using BugLogger.DataLayer;
    using BugLogger.Models;
    using BugLogger.RestApi.Models;

    public class BugsController : ApiController
    {
        private IBugLoggerData data;

        public BugsController()
            : this(new BugLoggerData())
        {
        }

        public BugsController(IBugLoggerData data)
        {
            this.data = data;
        }

        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            var bugs = this.data.Bugs.All().Select(BugModel.FromBug);
            
            return Ok(bugs);
        }

        //public IHttpActionResult GetCount(int count)
        //{
        //    return Ok(this.Get()
        //            .Take(count));
        //}

        public IHttpActionResult Get(int id)
        {
            var bugs = this.data.Bugs.All()
                .Where(b => b.Id == id)
                .Select(BugModel.FromBug);

            return Ok(bugs);
        }

        public IHttpActionResult Get(string date)
        {
            DateTime searchedDate;
            if (!DateTime.TryParse(date, out searchedDate))
            {
                return this.BadRequest("Date isn't in valid format! Please use YYYY-MM-DD");
            }

            var bugs = this.data.Bugs.All().Where(b => b.LogDate.GetValueOrDefault().Day == searchedDate.Day
                        && b.LogDate.GetValueOrDefault().Month == searchedDate.Month
                        && b.LogDate.GetValueOrDefault().Year == searchedDate.Year)
                        .Select(BugModel.FromBug);

            return this.Ok(bugs);
        }

        public IHttpActionResult GetAllByStatus(string type)
        {
            Status status;
            if (!Enum.TryParse(type, true, out status))
            {
                return this.BadRequest("No such status type in the DB");
            }

            var bugs = this.data.Bugs.All()
                .Where(b => b.Status == status)
                .Select(BugModel.FromBug);

            return this.Ok(bugs);
        }

        public IHttpActionResult PostBug(BugModel bug)
        {
            if (string.IsNullOrEmpty(bug.Text))
            {
                var ex = new ArgumentException();
                return this.BadRequest(ex.Message);
            }

            var newBug = new Bug
            {
                LogDate = DateTime.Now,
                Status = Status.Pending,
                Text = bug.Text
            };

            this.data.Bugs.Add(newBug);
            this.data.SaveChanges();

            var location = new Uri(this.Url.Link("DefaultApi", new { id = newBug.Id }));
            var response = this.Created(location, newBug);
            return response;
        }

        [HttpPut]
        public IHttpActionResult ChangeStatus(int id)
        {
            var existingBug = this.data.Bugs.All()
                .Where(b => b.Id == id)
                .FirstOrDefault();

            existingBug.Status = Status.Assigned;
            this.data.SaveChanges();

            var response = this.Ok();
            return response;
        }
    }
}
