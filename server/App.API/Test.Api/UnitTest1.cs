using App.API.Controllers;
using App.API.Data;
using App.API.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Api
{
    //Configure and make the unit tests for office and users
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestOfficeController()
        {
            //Arrange
            var controller = new OfficeController(null);

            //act
            var result = controller.GetOffices("");

            //assert
            Assert.IsTrue(result != null);
        }


        [TestMethod]
        public void TestUserController()
        {

            //Arrange
            var controller = new UserController(null);

            //act - Don't forget to send the user id
            var result = controller.GetUsers("");

            //assert
            Assert.IsTrue(result != null);
        }
    }
}
