using Balta.NotificationContext;

namespace Balta.SharedContext;

public abstract class Base : Notifiable
{
    public Base()
    {
        Id = Guid.NewGuid(); // SPOF: single point of failure
    }
    public Guid Id { get; set; }
}