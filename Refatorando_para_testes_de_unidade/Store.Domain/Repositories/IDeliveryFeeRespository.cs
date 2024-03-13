namespace Store.Domain.Repositories;

public interface IDeliveryFeeRespository
{
    decimal Get(string zipCode);
}