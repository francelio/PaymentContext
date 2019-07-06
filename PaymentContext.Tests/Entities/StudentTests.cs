using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities {
    [TestClass]
    public class StudentTests {
        [TestMethod]
        public void TestMethod1 () {
            var student = new Student ("Francelio", "Alencar", "23443223", "francelio.si@gmail.com");

        }

    }
}