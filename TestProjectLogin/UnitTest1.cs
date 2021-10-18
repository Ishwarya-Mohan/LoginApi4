using NUnit.Framework;
using LoginAPI1.Service;
using Moq;
using LoginAPI1.ELearnModel;
using System.Collections.Generic;

namespace TestProjectLogin
{
    [TestFixture]
    public class Tests
    {
        public Mock<IUserAccountServ<UserAccount>> cmock;
        public Login us;
        public Login usr;
        [SetUp]
        public void Setup()
        {
            us = new Login();
            List<Login> lg = new List<Login>
            {
                new Login{Username="user1",Password="user1"}
            };
            cmock = new Mock<IUserAccountServ<UserAccount>>();
        }

        [Test]
      
     
        public void Login()
        {
            List<Login> lg = new List<Login>();
            //string Username = "user1";
            //string Password = "user1";
            cmock = new Mock<IUserAccountServ<UserAccount>>();
            ELearnApp1Context eapp = new ELearnApp1Context();
            string actual = us.Username;
            string ecpect = "user1";
            Assert.AreEqual(ecpect, actual);

        }
    }
}