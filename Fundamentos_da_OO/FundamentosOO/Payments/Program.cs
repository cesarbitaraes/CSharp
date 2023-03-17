
namespace Payments;

public class Program
{
    static void Main(string[] args)
    {
        // Todo objeto (customer) é um tipo de referência. Armazena apenas o endereço. Fica armazenado na memória heap.
        // Tipos de valor são armazenados na memória stack, que é mais rápida.
        var customer = new Customer(); 
    }
    
}

class Customer
{
    public string Name { get; set; }
}

class Payment
{
    // Encapsulamento (primeiro pilar): agrupar o que faz sentido estar junto. Nesse caso é criar tudo o que é de pagamento dentro da sua classe.
    // Abstração (segundo pilar): esconder tudo aquilo que a gente não precisa saber sobre o nosso objeto. Métodos privados são um exemplo.
    
    // Propriedades
    public DateTime Vencimento { get; set; }

    // Métodos
    void Pagar()
    {
        ConsultarSaldoDoCartao();

    }

    private void ConsultarSaldoDoCartao()
    {
        
    }
}