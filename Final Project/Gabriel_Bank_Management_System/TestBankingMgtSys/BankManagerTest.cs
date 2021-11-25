using System;
using Xunit;
using Gabriel_Bank_Management_System;
using System.Linq;
using System.Collections.Generic;
using Moq;
using System.IO;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;
using BankingWebAPI.Interfaces;
using System.Data.Entity;
using System.Web.Http.Results;
using BankingWebAPI.EntityFramework;
using System.Web.Http;

namespace BankManagerTest
{
    public class BankManagerTest
    {
        private readonly Mock<IDataContext> _mockDataContext;

        public BankManagerTest()
        {
            _mockDataContext = new Mock<IDataContext>(MockBehavior.Strict);
        }
        [Fact]
        public void TestCreateManagerAccount()
        {
            ManagerAccountManagerController bmgt = new ManagerAccountManagerController();


            Dictionary<string, BankManagers> mockdictionaryOfManagers = new Dictionary<string, BankManagers>();
            var new_user = new BankManagers("1", "karen", "23 hillview", DateTime.Now, "loan manager", "3", "karen12345678");
            Assert.NotNull(new_user);
            Assert.Null(new_user);
            Assert.Contains(mockdictionaryOfManagers, item => item.Key == new_user.bankmanager_id);


            mockdictionaryOfManagers.Add(new_user.bankmanager_id, new_user);

        }
        [Theory]
        [InlineData("1234")]
        public void DeleteManagerTest(string id)
        {
            ManagerAccountManagerController mgr = new ManagerAccountManagerController();
            mgr.DeleteManager(id);
        }
        [Fact]
        public void TestManagerAdd()
        {
            ManagerAccountManagerController mam = new ManagerAccountManagerController();
            BankManagers mgr = new BankManagers("1", "karen", "25 hillview", DateTime.Now, "loan manager", "3", "Karen12345678$");
            mam.ManagerAdd(mgr);
        }
        [Fact]
        public void SignUpManagerTest()
        {
            string bankmanager_id = "1234"; string bankmanager_name = "karensmith"; string bankmanager_address = "23"; DateTime bankmanager_dob = DateTime.Now; string bankmanager_designation = "loan employee"; string bankmanager_yos = "3"; string bankmanager_pw = "Karen12345678$";
            var mockUserDbSet = new Mock<DbSet<BankManagers>>();
            _mockDataContext.Setup(t => t.Managers).Returns(mockUserDbSet.Object);
            _mockDataContext.Setup(t => t.SaveChanges()).Returns(1);

            var authenticationController = new ManagerAccountManagerController(_mockDataContext.Object);

            var signUpResult = authenticationController.SignUpManager(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);

            mockUserDbSet.Verify(t => t.Add(It.IsAny<BankManagers>()), Times.Once());
            _mockDataContext.Verify(t => t.SaveChanges(), Times.Once());
            Assert.IsType<OkResult>(signUpResult);
        }
        [Theory]
        [InlineData("1234", "Karen12345678$")]
        public void LoginTestManagerFail(string userName, string passWord)
        {
            var userList = new List<BankManagers>
            {
                new BankManagers("1", "karensmith", "23 hillview", DateTime.Now, "loan manager", "3", "Karen12345678$")
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<BankManagers>>();
            mockUserDbSet.As<IQueryable<BankManagers>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<BankManagers>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<BankManagers>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<BankManagers>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Managers).Returns(mockUserDbSet.Object);

            var authenticationController = new ManagerAccountManagerController(_mockDataContext.Object);

            var idResult = authenticationController.Login(userName, passWord);
            Assert.Equal((false, false), idResult);
            ;
        }
        [Theory]
        [InlineData("1234", "Karen12345678$")]
        public void LoginTestManager(string userName, string passWord)
        {
            var userList = new List<BankManagers>
            {
                new BankManagers("1234", "karensmith", "23 hillview", DateTime.Now, "loan manager", "3", "Karen12345678$")
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<BankManagers>>();
            mockUserDbSet.As<IQueryable<BankManagers>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<BankManagers>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<BankManagers>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<BankManagers>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Managers).Returns(mockUserDbSet.Object);

            var authenticationController = new ManagerAccountManagerController(_mockDataContext.Object);

            var idResult = authenticationController.Login(userName, passWord);
            Assert.Equal((true, true), idResult);
            ;
        }
        [Fact]
        public void ViewAllManagersTest()
        {
            BankManagers manager = new BankManagers() { bankmanager_id = "1111", bankmanager_name = "jamesmith", bankmanager_address = "23 hillview", bankmanager_dateOfBirth = DateTime.Parse("13 Oct 1992"), bankmanager_designation = "Relationship Manager", bankmanager_yearsOfService = "3", bankmanager_pw = "Karen12345678$" };

            var data = new List<BankManagers>
            {
                manager
            }.AsQueryable();

            var mockSet = new Mock<DbSet<BankManagers>>();
            mockSet.As<IQueryable<BankManagers>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<BankManagers>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<BankManagers>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<BankManagers>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Managers).Returns(mockSet.Object);

            ManagerAccountManagerController ac = new ManagerAccountManagerController(mockContext.Object);
            IHttpActionResult res = ac.ViewAllManagers();
            var contentResult = res as OkNegotiatedContentResult<IEnumerable<BankManagers>>;

            Assert.Contains(manager, contentResult.Content);
        }
        [Fact]
        public void ViewAllManagersEmpty()
        {
            

            var data = new List<BankManagers>
            {
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<BankManagers>>();
            mockSet.As<IQueryable<BankManagers>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<BankManagers>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<BankManagers>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<BankManagers>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Managers).Returns(mockSet.Object);

            ManagerAccountManagerController ac = new ManagerAccountManagerController(mockContext.Object);
            IHttpActionResult res = ac.ViewAllManagers();
            var contentResult = res as OkNegotiatedContentResult<string>;

            Assert.Equal("Invalid Manager ID", contentResult.Content);
        }
    }
}
