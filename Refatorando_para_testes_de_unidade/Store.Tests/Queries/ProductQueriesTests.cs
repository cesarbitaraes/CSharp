using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries;

[TestClass]
public class ProductQueriesTests
{
    private IList<Product> _products;

    public ProductQueriesTests()
    {
        _products = new List<Product>();
        _products.Add(new Product("Produto 01", 10, true));
        _products.Add(new Product("Produto 02", 20, true));
        _products.Add(new Product("Produto 03", 30, true));
        _products.Add(new Product("Produto 04", 40, false));
        _products.Add(new Product("Produto 05", 50, false));
    }
    
    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
    {
        var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());

        Assert.AreEqual(3, result.Count());
        Assert.AreEqual("Produto 01", result.ElementAt(0).Title);
        Assert.AreEqual("Produto 02", result.ElementAt(1).Title);
        Assert.AreEqual("Produto 03", result.ElementAt(2).Title);
        Assert.AreEqual(10, result.ElementAt(0).Price);
        Assert.AreEqual(20, result.ElementAt(1).Price);
        Assert.AreEqual(30, result.ElementAt(2).Price);
        Assert.AreEqual(true, result.ElementAt(0).Active);
        Assert.AreEqual(true, result.ElementAt(1).Active);
        Assert.AreEqual(true, result.ElementAt(2).Active);
    }
    
    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
    {
        var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());

        Assert.AreEqual(2, result.Count());
        Assert.AreEqual("Produto 04", result.ElementAt(0).Title);
        Assert.AreEqual("Produto 05", result.ElementAt(1).Title);
        Assert.AreEqual(40, result.ElementAt(0).Price);
        Assert.AreEqual(50, result.ElementAt(1).Price);
        Assert.AreEqual(false, result.ElementAt(0).Active);
        Assert.AreEqual(false, result.ElementAt(1).Active);
    }
}