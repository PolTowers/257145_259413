namespace Domain.test
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void ReturnsFalseIfNameisVoid()
        {
            string name = "";
            Client client = new Client();
            bool result = client.VerifyName(name);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseForShortName()
        {
            string name = "a1";
            Client client = new Client();
            bool result = client.VerifyName(name);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseForLongName()
        {
            string name = "aaaaaaaaaaa1aaaaa2aaaaaaaaa";
            Client client = new Client();
            bool result = client.VerifyName(name);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsTrueIfAlphanumericName()
        {
            string name = "aa1";
            Client client = new Client();
            bool result = client.VerifyName(name);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnsFalseIfNameHasAnySpaces()
        {
            string name = "a1 aaa";
            Client client = new Client();
            bool result = client.VerifyName(name);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseIfVoidPassword()
        {
            string password = "";
            Client client = new Client();
            bool result = client.VerifyPassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseForShortPassword()
        {
            string password = "a1";
            Client client = new Client();
            bool result = client.VerifyPassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseForLongPassword()
        {
            string password = "aaaaaaaaaaa1aaaaa2aaaaaaaaa";
            Client client = new Client();
            bool result = client.VerifyPassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseIfNotAlphanumericPassword()
        {
            string password = "aaaaaa";
            Client client = new Client();
            bool result = client.VerifyPassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnsFalseIfNotUpperCasePassword()
        {
            string password = "a123bc";
            Client client = new Client();
            bool result = client.VerifyPassword(password);
            Assert.IsFalse(result);
        }
    }
}