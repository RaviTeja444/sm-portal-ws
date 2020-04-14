using NUnit.Framework;
using Moq;
using StudentsManagementPortal.Interfaces;
using StudentsManagementPortal.Controllers;
using StudentsManagementPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementPortalTests
{
    public class Tests
    {
        private Mock<IUtility> mockUtility;
        [SetUp]
        public void Setup()
        {
            mockUtility = new Mock<IUtility>();
            
        }

        [Test]
        public void ValidateUser()
        {
            AccountController account = new AccountController(mockUtility.Object);
            mockUtility.Setup(x => x.getContext()).Returns(It.IsAny<AdminContext>());
            mockUtility.Setup(x => x.isValidLogin(It.IsAny<AdminContext>(), It.IsAny<Admins>())).Returns(true);
            Admins admins = new Admins();
            ActionResult result = account.Validate(admins);
            Assert.IsNotNull(result);
        }
    }
}