namespace Payments;

public class Generics
{
    static void Main3(string[] args)
    {
        var person = new Person();
        var payment = new Payment();
        var subscription = new Subscription();
        var context = new DataContext<IPerson, Payment, Subscription>();
        context.Save(person);
        context.Save(payment);
        context.Save(subscription);
    }
    
    public class DataContext<P, PA, S>
        where P : IPerson
        where PA : Payment
        where S : Subscription
    {
        public void Save(P entity)
        {
        }
        
        public void Save(PA entity)
        {
        }
        
        public void Save(S entity)
        {
        }
        
    }
    
    public class Person : IPerson
    {
    }
    
    public interface IPerson
    {
        
    }
    
    public class Payment
    {
    }
    
    public class Subscription
    {
    }
}