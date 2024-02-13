using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    // Red, Green, Refactor
    
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsFalse(doc.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("12345678912345", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsFalse(doc.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnSuccessWhenCPFIsValid()
    {
        var doc = new Document("08935774642", EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}