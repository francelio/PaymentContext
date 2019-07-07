using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects {
    [TestClass]
    public class DocumentTests {
        //Red, Gren, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid () {
            var doc=new Document("47938748329",EDocumentType.CNPJ);
            Assert.IsTrue (doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid () {
            var doc=new Document("34110468000150",EDocumentType.CNPJ);
            Assert.IsTrue (doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid () {
           var doc=new Document("34110468000150",EDocumentType.CPF);
            Assert.IsTrue (doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("34225545806")]
        [DataRow("54139739347")]
        [DataRow("01077284608")]
        public void ShouldReturnSuccessWhenCPFIsValid (string cpf) {
            var doc=new Document(cpf,EDocumentType.CPF);
            Assert.IsTrue (doc.Valid);

        }
    }
}