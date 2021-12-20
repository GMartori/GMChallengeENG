using GMChallengeENG.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ActiveOrNot()
        {
            object result = UsersController.IsActive();
            string msg = result.ToString();
            // Assert  
            Assert.AreEqual("User NOT Active", msg);
        }
    }
}
