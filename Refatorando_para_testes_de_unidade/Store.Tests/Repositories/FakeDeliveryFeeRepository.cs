using Store.Domain.Repositories;

namespace Store.Tests.Repositories;

public class FakeDeliveryFeeRepository : IDeliveryFeeRespository
{
    public decimal Get(string zipCode)
    {
        return 10;
    }
}