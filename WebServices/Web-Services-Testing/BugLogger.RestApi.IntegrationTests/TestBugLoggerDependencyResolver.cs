namespace BugLogger.RestApi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    using BugLogger.DataLayer;
    using BugLogger.RestApi.Controllers;

    class TestBugsDependencyResolver : IDependencyResolver
    {
        private IBugLoggerData data;

        public IBugLoggerData Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            //add all controllers
            if (serviceType == typeof(BugsController))
            {
                return new BugsController(this.data);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {

        }
    }
}
