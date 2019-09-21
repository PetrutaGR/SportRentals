using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportRentals.Repository;

namespace SportRentals.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repo = new UserRepository();

            var user = repo.GetUserID("gabrielarotar26@gmail.com");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var repo = new ShopRepository();

            var result = repo.GetAllShops();
        }
    }
}
