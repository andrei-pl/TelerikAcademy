using System.Data.Entity;
using System.Transactions;
using BugLogger.DataLayer;
using BugLogger.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugLogger.Models;

namespace BugLogger.Repositories.Tests
{
    [TestClass]
    public class DbBugLoggerRepositoryTests
    {
        static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Find_WhenObjectIsInDb_ShouldReturnObject()
        {
            //arrange
            var bug = this.GetValidTestBug();

            var dbContext = new BugLoggerDbContext();
            var data = new BugLoggerData(dbContext);

            dbContext.Bugs.Add(bug);
            dbContext.SaveChanges();

            //act
            var bugInDb = data.Bugs.All().Where(x => x.Text == bug.Text).FirstOrDefault();

            //asesrt

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void AddBug_WhenBugIsValid_ShouldAddToDb()
        {
            //arrange -> prapare the objects
            var bug = GetValidTestBug();

            var dbContext = new BugLoggerDbContext();
            var repo = new BugLoggerData(dbContext);

            //act -> test the objects

            repo.Bugs.Add(bug);
            repo.Bugs.Save();

            //assert -> validate the result

            var bugInDb = dbContext.Bugs.Find(bug.Id);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }
  
        private Bug GetValidTestBug()
        {
            var bug = new Bug()
            {
                Text = "Test New bug",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };
            return bug;
        }
    }
}
