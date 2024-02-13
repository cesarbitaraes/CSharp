using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Student _student;
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("José", "Silva");
        _document = new Document("12345678910", EDocumentType.CPF);
        _email = new Email("josesilva@teste.com");
        _address = new Address("Rua 1", "123", "Bairro", "Cidade", "Estado", "Pais", "CEP");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
    }
    
    
    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PayPalPayment(DateTime.Today, DateTime.Now, 10, 10, "José Silva", _document, _address, _email, "");
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);
        
        Assert.IsFalse(_student.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);
        
        Assert.IsFalse(_student.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
        var payment = new PayPalPayment(DateTime.Today, DateTime.Now, 10, 10, "José Silva", _document, _address, _email, "");
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        
        Assert.IsTrue(_student.IsValid);
    }
}